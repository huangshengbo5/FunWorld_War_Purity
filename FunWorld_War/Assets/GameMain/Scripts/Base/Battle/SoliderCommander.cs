using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderCommander
{
    private List<Solider> soliders;
    
    //归属的城镇
    private Town ownerTown;

    //目标城镇
    private Town targetTown;
    
    public List<Solider> Soliders
    {
        get => soliders;
        set => soliders = value;
    }

    public Town TargetTown
    {
        get => targetTown;
        set => targetTown = value;
    }

    //归属的阵营，不能为空
    private CampType camp;

    public Town OwnerTown
    {
        get => ownerTown;
        set => ownerTown = value;
    }

    public CampType Camp
    {
        get => camp;
        set => camp = value;
    }

    public void Init(Town ownerTown,Town targetTown)
    {
        OwnerTown = ownerTown;
        TargetTown = targetTown;
        soliders = new List<Solider>();
        Camp = OwnerTown.Camp();
    }
    public void AddSolider(Solider solider)
    {
        soliders.Add(solider);
        solider.Init_SoliderCommander(this);
    }

    public void AddSoliders(List<Solider> soliders)
    {
        this.soliders.AddRange(soliders);
        foreach (var solider in soliders)
        {
            solider.Init_SoliderCommander(this);
        }
    }

    public void RemoveSolider(Solider solider)
    {
        if (soliders.Contains(solider))
        {
            soliders.Remove(solider);
        }
        //部队全部阵亡，退出战斗
        if (soliders.Count == 0)
        {
            targetTown.TownBattleJudge.LeaveBattle(this);
        }
    }
    //战斗胜利
    public void OnBattleWin()
    {
        //执行士兵进城
        for (int i = 0; i < soliders.Count; i++)
        {
            soliders[i].EnterTown();
        }
    }
    
    //攻城
    public void AttackTown(BaseObject targetTown)
    {
        //执行士兵攻城
        for (int i = 0; i < soliders.Count; i++)
        {
            soliders[i].ChangeTargetObject(targetTown);
        }
    }

    //撤退
    public void Retreat()
    {
        //执行士兵攻城
        for (int i = 0; i < soliders.Count; i++)
        {
            soliders[i].Retreat();
        }
    }

    //入城
    public void EnterTown(BaseObject targetTown)
    {
        for (int i = 0; i < soliders.Count; i++)
        {
            soliders[i].ChangeTargetObject(targetTown);
        }
    }

    //所属的士兵请求一个目标，当前目标应当为士兵，当所有敌对士兵都被杀死，才能回城
    public BaseObject SoliderFindTarget(Solider solider)
    {
        if (targetTown != null && targetTown.TownBattleJudge !=null)
        {
            return targetTown.TownBattleJudge.SoliderCommanderFindTarget(solider);    
        }
        return null;
    }
}