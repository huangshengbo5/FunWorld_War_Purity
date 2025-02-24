using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public class MenuForm : UIFormLogic
{
    [SerializeField]
    private Button Btn_Survival;

    private ProcedureMenu ProcedureMenu;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        ProcedureMenu = userData as ProcedureMenu;
        Btn_Survival.onClick.AddListener(OnBtnSurvivalClick);
    }
    
    public void OnBtnSurvivalClick()
    {
        ProcedureMenu.StartGame();
    }
    
    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        base.OnClose(isShutdown, userData);
    }

    public void Close(bool isShutDown)
    {
        GameEntry.UI.CloseUIForm(this);
    }
}