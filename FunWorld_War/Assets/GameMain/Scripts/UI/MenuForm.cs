using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public class MenuForm : UIFormLogic
{
    [SerializeField]
    private Button Btn_Survival;

    [SerializeField]
    private Button Btn_AbilityTest;
    
    private ProcedureMenu ProcedureMenu;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        ProcedureMenu = userData as ProcedureMenu;
        Btn_Survival.onClick.AddListener(OnBtnSurvivalClick);
        Btn_AbilityTest.onClick.AddListener(OnBtnAbilityTestClick);
    }

    public void OnBtnAbilityTestClick()
    { 
        ProcedureMenu.StartGame(2);
    }

    public void OnBtnSurvivalClick()
    {
        ProcedureMenu.StartGame(GameEntry.Config.GetInt("Scene.Main"));
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