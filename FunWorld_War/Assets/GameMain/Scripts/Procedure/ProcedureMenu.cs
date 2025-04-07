using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class ProcedureMenu : ProcedureBase
{
    private bool m_StartGame = false;
    private MenuForm m_MenuForm = null;
    private SceneId sceneId;

    public override bool UseNativeDialog => false;

    public void StartGame(SceneId sceneId)
    {
        this.sceneId = sceneId;
        m_StartGame = true;
    }

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

        m_StartGame = false;
        GameEntry.UI.OpenUIForm(UIFormId.MenuForm, this);
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);

        GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

        if (m_MenuForm != null)
        {
            m_MenuForm.Close(isShutdown);
            m_MenuForm = null;
        }
    }

    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (m_StartGame)
        {
            //GameEntry.UI.CloseUIForm(UIFormId.MenuForm);
            //procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Main"));
            procedureOwner.SetData<VarInt32>("NextSceneId", (int)sceneId);
            var gameMode = GameEntry.ScriptConfig.SceneConfig.GetGameMode(sceneId);
            procedureOwner.SetData<VarByte>("GameMode",(byte)gameMode);
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }
    }

    private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
    {
        var ne = (OpenUIFormSuccessEventArgs)e;
        if (ne.UserData != this) return;

        m_MenuForm = (MenuForm)ne.UIForm.Logic;
    }
}