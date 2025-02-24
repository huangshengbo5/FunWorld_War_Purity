using GameFramework.Fsm;
using Script.Game.Base;
using UnityEngine;

public class FSMTownIdle : FsmState<Town>
{
    protected override void OnInit(IFsm<Town> fsm)
    {
        base.OnInit(fsm);
    }

    protected override void OnEnter(IFsm<Town> fsm)
    {
        base.OnEnter(fsm);
    }

    protected override void OnUpdate(IFsm<Town> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        if (fsm.Owner.IsInBattle())
        {
            ChangeState<FSMTownBattle>(fsm);
        }
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