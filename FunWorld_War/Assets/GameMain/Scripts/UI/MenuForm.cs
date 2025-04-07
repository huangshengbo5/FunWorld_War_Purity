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

    [SerializeField]
    private Button Btn_Survival_Formal;
    
    private ProcedureMenu ProcedureMenu;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        ProcedureMenu = userData as ProcedureMenu;
#if UNITY_EDITOR
        Btn_Survival.gameObject.SetActive(true);
        Btn_AbilityTest.gameObject.SetActive(true);
        Btn_Survival_Formal.gameObject.SetActive(true);
        Btn_Survival.onClick.AddListener(OnBtnSurvivalClick);
        Btn_AbilityTest.onClick.AddListener(OnBtnAbilityTestClick);
#else
        Btn_Survival.gameObject.SetActive(false);
        Btn_AbilityTest.gameObject.SetActive(false);
#endif
        Btn_Survival_Formal.onClick.AddListener(OnBtnSurvivalFormalClick);
    }

    public void OnBtnAbilityTestClick()
    { 
        ProcedureMenu.StartGame(SceneId.Ability_Test);
    }

    public void OnBtnSurvivalFormalClick()
    {
        ProcedureMenu.StartGame(SceneId.Battle_Formal);
    }
    
    public void OnBtnSurvivalClick()
    {
        ProcedureMenu.StartGame(SceneId.Battle_Test);
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