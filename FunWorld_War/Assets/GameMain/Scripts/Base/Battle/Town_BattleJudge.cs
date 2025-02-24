using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Town_BattleJudge
{
    //参与夺城的部队
    private Dictionary<CampType, List<SoliderCommander>> LeftSoliderCommanders;
    private List<Solider> fightingSoliders;
    private List<Solider> noFightingSoliders ;
    //当前争夺的城池
    private Town ownerTown;

    Tuple<bool, CampType> battleResult;
    
    public void Init(Town town)
    {
        ownerTown = town;
        LeftSoliderCommanders = new Dictionary<CampType, List<SoliderCommander>>();
    }

    public bool EnemySoliderCommandersContainPlayer()
    {
        if (ownerTown.Camp() == CampType.Player)
        {
            return false;
        }
        if (LeftSoliderCommanders.ContainsKey(CampType.Player))
        {
            return true;
        }
        return false;
    }

    public void PlayerSoliderCommanderRetreat()
    {
        var result = CheckBattleResult();
        if (result.Item1 == false)
        {
            if (LeftSoliderCommanders.ContainsKey(CampType.Player))
            {
                var soliderCommanders = LeftSoliderCommanders[CampType.Player];
                for (int i = 0; i < soliderCommanders.Count; i++)
                {
                    var soliderCommander = soliderCommanders[i];
                    soliderCommander.Retreat();
                    LeaveBattle(soliderCommander);
                }
            }            
        }
    }
    
    //加入一场战斗
    public void JoinBattle(SoliderCommander soliderCommander)
    {
        var camp = soliderCommander.Camp;
        if (!LeftSoliderCommanders.ContainsKey(camp))
        {
            LeftSoliderCommanders[camp] = new List<SoliderCommander>();
        }
        LeftSoliderCommanders[camp].Add(soliderCommander);
    }
    
    //士兵部队离开一场战斗，士兵部队的人全部被消灭
    public void LeaveBattle(SoliderCommander soliderCommander)
    {
        var camp = soliderCommander.Camp;
        if (LeftSoliderCommanders.ContainsKey(camp))
        {
            if (LeftSoliderCommanders[camp].Contains(soliderCommander))
            {
                LeftSoliderCommanders[camp].Remove(soliderCommander);
            }
        }
        if (LeftSoliderCommanders.ContainsKey(camp) && LeftSoliderCommanders[camp].Count == 0)
        {
            LeftSoliderCommanders.Remove(camp);
        }
    }
    
    public void DoUpdate()
    {
        var result = CheckBattleResult();
        if (result.Item1 == false)  //战斗未结束
        {
            if (result.Item2 != CampType.None) //只剩余一只部队
            {
                if (result.Item2 == ownerTown.Camp())  //守城成功
                {
                    Town_ProtectSuccess(result.Item2);
                }
                foreach (var commander in LeftSoliderCommanders)
                {
                    foreach (var soliderCommander in commander.Value)
                    {
                        soliderCommander.AttackTown(ownerTown);
                    }
                }
            }
        }
    }
    
    //是否还在战斗中
    public bool IsInBattle()
    {
        return LeftSoliderCommanders.Count > 0;
    }
    

    //检查战斗结果
    public Tuple<bool, CampType> CheckBattleResult()
    {
        CampType leftCamp = CampType.None;
        if (LeftSoliderCommanders.Count  == 1)
        {
            foreach (var commander in LeftSoliderCommanders)
            {
                if (leftCamp == CampType.None)
                {
                    leftCamp = commander.Key;     
                }
            }
        }
        var battleEnd = ownerTown.IsOccupied == true && leftCamp != CampType.None;
        battleResult = new Tuple<bool, CampType>(battleEnd, leftCamp);
        return battleResult;
    }

    //占城成功
    public void Town_OccupiedSuccess()
    {
        Tuple<bool, CampType> battleResult = CheckBattleResult();
        if (battleResult.Item1 == false)
        {
            Debug.LogError("城池已被攻占，战斗却尚未结束！！！");
            return;
        }
        var winner_camp = battleResult.Item2;
        ownerTown.BeOccupied(winner_camp);
        Debug.Log($"城池已被占领，胜利方阵营为：{winner_camp}");
        LeftSoliderCommanders[winner_camp][0].OnBattleWin();
        BattleEnd();
    }
    
    public void BattleEnd()
    {
        LeftSoliderCommanders.Clear();
        fightingSoliders.Clear();
        noFightingSoliders.Clear();
    }
    
    //守城成功
    public void Town_ProtectSuccess(CampType winnerCamp)
    {
        Debug.Log("守城成功！！");
        ownerTown.BeOccupied(winnerCamp);
        LeftSoliderCommanders[winnerCamp][0].OnBattleWin();
        BattleEnd();
    }
    
    //士兵部队寻找一个敌方士兵
    public BaseObject SoliderCommanderFindTarget(Solider solider)
    {
        if (IsInBattle()==false)
        {
            return null;
        }

        if (fightingSoliders == null) fightingSoliders = new List<Solider>();
        if (noFightingSoliders == null) noFightingSoliders = new List<Solider>();
        fightingSoliders.Clear();
        noFightingSoliders.Clear();
        foreach (var soliderCommander in LeftSoliderCommanders)
        {
            if (soliderCommander.Key != solider.CampType)
            {
                for (int i = 0; i < soliderCommander.Value.Count; i++)
                {
                    var soliderCommanderItem = soliderCommander.Value[i];
                    for (int j = 0; j < soliderCommanderItem.Soliders.Count; j++)
                    {
                        var soliderItem = soliderCommanderItem.Soliders[j];
                        if (soliderItem.IsDead())
                        {
                            continue;
                        }
                        //var dis = Vector3.Distance(solider.transform.position, soliderItem.transform.position);
                        if (soliderItem.TargetObject != null) fightingSoliders.Add(soliderItem);
                        else noFightingSoliders.Add(soliderItem);
                    }
                }
            }
        }
        
        foreach (var noFightingSoliderItem in noFightingSoliders)
        {
            return noFightingSoliderItem;
        }
        foreach (var fightingSoliderItem in fightingSoliders)
        {
            return fightingSoliderItem;
        }
        return ownerTown;
    }
}