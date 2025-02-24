using GameFramework.Fsm;
using Script.Game.Base;
using UnityEngine;

public class FSMTownBattleEnd : FsmState<Town>
{
    protected override void OnInit(IFsm<Town> fsm)
    {
        base.OnInit(fsm);
    }

    protected override void OnEnter(IFsm<Town> fsm)
    {
        base.OnEnter(fsm);
        var result = fsm.Owner.CheckBattleResult();
        var townOwnerType = result.Item2;
        //fsm.Owner.ChangeCamp(townOwnerType);
    }

    protected override void OnUpdate(IFsm<Town> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
    }

    protected override void OnLeave(IFsm<Town> fsm, bool isShutdown)
    {
        base.OnLeave(fsm, isShutdown);
    }

    protected override void OnDestroy(IFsm<Town> fsm)
    {
        base.OnDestroy(fsm);
    }
}