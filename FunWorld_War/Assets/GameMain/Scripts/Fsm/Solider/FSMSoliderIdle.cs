using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using UnityEngine;
using UnityGameFramework.Runtime;

public class FSMSoliderIdle : FsmState<Solider>
{
    protected override void OnInit(IFsm<Solider> fsm)
    {
        base.OnInit(fsm);
    }

    protected override void OnEnter(IFsm<Solider> fsm)
    {
        base.OnEnter(fsm);
        fsm.Owner.ChangeAnimatorState(Solider.State.Idleing);
    }

    protected override void OnLeave(IFsm<Solider> fsm, bool isShutdown)
    {
        base.OnLeave(fsm, isShutdown);
    }

    protected override void OnUpdate(IFsm<Solider> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        if (fsm.Owner.TargetObject!= null)
        {
            ChangeState<FSMSoliderAttack>(fsm);
        }
        if (fsm.Owner.GetTargetObject() != null)
        {
            ChangeState<FSMSoliderMoveToTarget>(fsm);
        }
        if (fsm.Owner.IsDead())
        {
            ChangeState<FSMSoliderDead>(fsm);
        }
    }

    protected override void OnDestroy(IFsm<Solider> fsm)
    {
        base.OnDestroy(fsm);
    }
}