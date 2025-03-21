using EGamePlay;
using EGamePlay.Combat;
using ET;

public class GameMode_AbilityTest : GameBase
{
    public override GameMode GameMode => GameMode.AbilityTest;
    public bool EntityLog;
    public override void Initialize()
    {
        base.Initialize();
        Entity.EnableLog = EntityLog;
        var EcsNode = ECSNode.Create();
        EcsNode.AddChild<CombatContext>();
        EcsNode.AddChild<TimerManager>();
        BattleManager.Instance().Initialize();
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
        ECSNode.Instance.Update();
        TimerManager.Instance.Update();
    }
}