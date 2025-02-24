using System;
using System.Collections.Generic;
using GameFramework.Event;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = System.Random;

public partial class Town : BaseObject
{
    private Town_BattleJudge townBattleJudge;
    private List<SoliderCommander> SoliderCommanders;
    
    /// <summary>
    /// 可以生成的士兵
    /// </summary>
    public GameObject ObjSolider;

    public Town_BattleJudge TownBattleJudge
    {
        get => townBattleJudge;
        set => townBattleJudge = value;
    }

    private void Start()
    {
        RegisterEvent();
        curSoliderNum = DefaultMaxSoliderNum;
    }

    private void ResetData()
    {
        CurHp = MaxHp;
        curSoliderNum = DefaultMaxSoliderNum;
        DelegateTownCampChange.Invoke(Camp());
        DelegateTownHpChange.Invoke(CurHp,MaxHp);
        DelegateTownSoliderNumChange(curSoliderNum, DefaultMaxSoliderNum);
    }
    
    private void Init()
    {
        TownHUD.Init(this);
        ResetData();
        var gameMode = Common.CurGameMode();
        var gameModeSurvival = gameMode as GameMode_Survival;
        if (gameModeSurvival != null)
        {
            gameModeSurvival.JoinBattle(this);
        }
        townBattleJudge = new Town_BattleJudge();
        townBattleJudge.Init(this);
    }
    
    private void RegisterEvent()
    {
        //GameEntry.Event.Subscribe(BattleSingleTownResultEventArgs.EventId,OnSingleTownResult); 
        GameEntry.Event.Subscribe(GameStartEventArgs.EventId,OnGameStart);
        //GameEntry.Event.Subscribe(BattleClickTargetTownRetreatEventArgs.EventId,OnSoliderCommanderRetreat);
    }

    void OnGameStart(object sender, GameEventArgs e)
    {
        Init();
    }

    // void OnSoliderCommanderRetreat(object sender, GameEventArgs e)
    // {
    //     BattleClickTargetTownRetreatEventArgs args = e as BattleClickTargetTownRetreatEventArgs;
    //             
    // }

    public void OnPlayerEnemySoliderCommanderRetreat()
    {
        townBattleJudge.PlayerSoliderCommanderRetreat();
    }
    
    //攻击敌方城池
    public void AttackTargetTown(Town targetTown)
    {
        TargetTown = targetTown;
        var soliderCommander = CreateSolider(targetTown);
        JoinBattle(TargetTown, soliderCommander);
    }
    
    // void OnSingleTownResult(object sender, GameEventArgs e)
    // {
    //     var eventData = e as BattleSingleTownResultEventArgs;
    //     var type = eventData.OwnerType;
    //     Debug.Log(string.Format("胜利{0}",type));
    // }
    
    protected  SoliderCommander CreateSolider(Town targetTown)
    {
        if (curSoliderNum  == 0)
        {
            return null;
        }
        List<Solider> Soliders = new List<Solider>();
        for (int i = 0; i < curSoliderNum; i++)
        {
            var createSolider = CreateSolider(i); 
            Soliders.Add(createSolider);
            createSolider.CampType = this.Camp();
            createSolider.Init();
            if (TargetTown)
            {
                createSolider.ChangeTargetObject(TargetTown);    
            }
        }

        SoliderCommander soliderCommander = new SoliderCommander();
        soliderCommander.Init(this,targetTown as Town);
        soliderCommander.AddSoliders(Soliders);
        CurSoliderNum = 0;
        return soliderCommander;
    }
    
    //创建士兵
    protected Solider CreateSolider(int index)
    {
        var solider = (GameObject)Instantiate(ObjSolider);
        solider.name = string.Format("Solider_{0}_{1}",ownerCamp.ToString(),index) ;
        var soliderTans = solider.GetComponent<Transform>();
        soliderTans.position = GetSoliderPosition();
        soliderTans.localScale = Vector3.one;
        soliderTans.rotation = Quaternion.identity;
        var soliderCom = solider.GetComponent<Solider>();
        soliderCom.OwnerTown = this;
        return soliderCom;
    }

    //获取士兵位置
    Vector3 GetSoliderPosition()
    {
        var selfPosition = this.gameObject.transform.position;
        var random = new Random();
        var posx = random.Next((int)selfPosition.x+3,(int)selfPosition.x+5);
        //var posy = random.Next((int)selfPosition.y,(int)selfPosition.y+10);
        var posz = random.Next((int)selfPosition.z+3,(int)selfPosition.z+5);
        return new Vector3(posx,0,posz);
    }

    //检查战斗结果
    public  Tuple<bool, CampType> CheckBattleResult()
    {
        return townBattleJudge.CheckBattleResult();
    }

    //是否正在发生战斗
    public  bool IsInBattle()
    {
        return townBattleJudge.IsInBattle();
    }

    //加入一只敌方部队
    public  void JoinBattle(SoliderCommander enemySoliderCommander)
    {
        townBattleJudge.JoinBattle(enemySoliderCommander);
    }

    public  void JoinBattle(Town targetTown, SoliderCommander enemySoliderCommander)
    {
        targetTown.JoinBattle(enemySoliderCommander);
    }
    
    //被攻击
    public override void BeAttack(BaseObject attacker, int damageNum)
    {
        if (IsOccupied == false)
        {
            SufferInjure(damageNum);
            if (CurHp <= damageNum)
            {
                IsOccupied = true;
                Solider solider = (Solider)attacker;
                GameEntry.Event.Fire(this,BattleSingleTownResultEventArgs.Create(this.ID,solider.CampType));
                //通知裁判，城池被占领
                townBattleJudge.Town_OccupiedSuccess();
                Debug.Log($"城池被占领，占领方:{solider.CampType}");
            }            
        }
    }
    
    public void SufferInjure(int injure)
    {
        CurHp -= injure;
        DelegateTownHpChange.Invoke(CurHp,MaxHp);
    }
}