using System;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public class BattleWinForm : UIFormLogic
{
    [SerializeField]
    private Button Btn_BG;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        Btn_BG.onClick.AddListener(OnFullBGBtnClick);
    }

    void OnFullBGBtnClick()
    {
        var curProcedure = GameEntry.Procedure.CurrentProcedure;
        if (curProcedure is ProcedureMain)
        {
            var procedureMain = curProcedure as ProcedureMain;
            procedureMain.GotoMenu();
        }
    }
    
    protected override void OnClose(bool isShutdown, object userData)
    {
        base.OnClose(isShutdown, userData);
    }
}