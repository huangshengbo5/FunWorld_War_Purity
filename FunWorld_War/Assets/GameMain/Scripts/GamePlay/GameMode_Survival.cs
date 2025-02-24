using System;
using System.Collections.Generic;
using System.Net.Mail;
using Script.Game.Base;
using UnityEngine;

public class GameMode_Survival : GameBase
{
    /// <summary>
    /// 当前所有参与战斗的城池
    /// </summary>
    ///
    [HideInInspector]
    private List<Town> allBattleTowns;

    public List<Town> AllBattleTowns
    {
        get { return allBattleTowns; }
    }
    
    private float m_ElapseSeconds = 0f;
    public override GameMode GameMode => GameMode.Survival;
    
    public Town CurOperateTown;

    public override void Initialize()
    {
        base.Initialize();
        GameEntry.Event.Subscribe(BattleClickTargetTownEventArgs.EventId,HandlerBattleClickTargetTown);
        GameEntry.Event.Subscribe(BattleClickPlayerTownEventArgs.EventId,HandlerBattleClickPlayerTown);
        GameEntry.Event.Subscribe(BattleSingleTownResultEventArgs.EventId,HandlerOnSingleTownResult); 
        GameEntry.Event.Fire(this,GameStartEventArgs.Create());
    }

    public override void Shutdown()
    {
        base.Shutdown();
        GameEntry.Event.Unsubscribe(BattleClickTargetTownEventArgs.EventId,HandlerBattleClickTargetTown);
    }

    public void HandlerBattleClickPlayerTown(object obj, EventArgs e)
    {
        var clickEvent = e as BattleClickPlayerTownEventArgs;
        CurOperateTown = clickEvent.Town;
    }
            
    public void HandlerBattleClickTargetTown(object s ,EventArgs e)
    {
        BattleClickTargetTownEventArgs clickEventArgs = e as BattleClickTargetTownEventArgs;
        if (clickEventArgs != null)
        {
            var TargetTown = clickEventArgs.Town;
            var town = CurOperateTown as Town;
            town.AttackTargetTown(TargetTown);
        }
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);

        m_ElapseSeconds += elapseSeconds;
        if (m_ElapseSeconds >= 1f) m_ElapseSeconds = 0f;
    }


    //todo 后面应该使用GameState来处理所有战场数据
    /// <summary>
    /// 城池加入战场
    /// </summary>
    /// <param name="town"></param>
    public void JoinBattle(Town town)
    {
        if (allBattleTowns == null)
        {
            allBattleTowns = new List<Town>();    
        }
        allBattleTowns.Add(town);
    }

    //获取所有敌对城池
    public List<Town> GetHostileTown(Town town)
    {
        List<Town> hostileTowns = new List<Town>();
        foreach (var townItem in allBattleTowns)
        {
            if (Common.GetRelation(townItem.Camp(),town.Camp()) == RelationType.Hostile)
            {
                hostileTowns.Add(townItem);
            }
        }
        return hostileTowns;
    }

    public void HandlerOnSingleTownResult(object sender, EventArgs args)
    {
        var singleTownArgs = args as BattleSingleTownResultEventArgs;
        bool havePlayerCampTown = false;
        bool haveOtherCampTown = false;
        foreach (var townItem in allBattleTowns)
        {
            if (townItem.Camp() == CampType.Player)
            {
                havePlayerCampTown = true;
            }
            else
            {
                haveOtherCampTown = true;
            }
        }

        if (!havePlayerCampTown || !haveOtherCampTown)
        {
            BattleResultType battleResultType = BattleResultType.Draw; 
            if (!havePlayerCampTown)
            {
                //玩家失败
                battleResultType = BattleResultType.Fail;
                GameEntry.UI.OpenUIForm(UIFormId.BattleFailForm);
            }
            else if (!haveOtherCampTown)
            {
                //玩家胜利
                battleResultType = BattleResultType.Win;
                GameEntry.UI.OpenUIForm(UIFormId.BattleWinForm);
            }
            GameEntry.Event.Fire(this,BattleResultEventArgs.Create(battleResultType));
        }
    }
}