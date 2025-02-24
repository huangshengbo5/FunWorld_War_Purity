using System;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public class BattleFailForm : UIFormLogic
{
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
    }
    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        AddEvent();
    }

    void AddEvent()
    {
     
    }

    void RemoveEvent()
    {
    }
    
    protected override void OnClose(bool isShutdown, object userData)
    {
        base.OnClose(isShutdown, userData);
        RemoveEvent();
    }
}