using System;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public class BattleMainForm : UIFormLogic
{
    public Button Btn_AllAttack;
    public GameObject Attack_Holder;
    private BattleClickPlayerTownEventArgs ClickPlayerTownEventArgs;
    
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        Btn_AllAttack.onClick.AddListener(OnClickAllAttack);
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        AddEvent();
    }

    void AddEvent()
    {
        GameEntry.Event.Subscribe(BattleClickPlayerTownEventArgs.EventId,HandlerBattleClickPlayerTown);
    }

    void RemoveEvent()
    {
        GameEntry.Event.Unsubscribe(BattleClickPlayerTownEventArgs.EventId,HandlerBattleClickPlayerTown);
    }

    void HandlerBattleClickPlayerTown(object o,EventArgs e)
    {
        ClickPlayerTownEventArgs = e as BattleClickPlayerTownEventArgs;
        Attack_Holder.SetActive(true);
    }

    private void OnClickAllAttack()
    {
        if (ClickPlayerTownEventArgs != null)
        {
            ClickPlayerTownEventArgs.Town.EnemyTownShowOperateUI();
        }
    }
    
    protected override void OnClose(bool isShutdown, object userData)
    {
        base.OnClose(isShutdown, userData);
        RemoveEvent();
    }
}