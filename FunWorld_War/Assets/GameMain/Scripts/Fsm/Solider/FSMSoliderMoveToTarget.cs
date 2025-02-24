using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using UnityEngine;

public class FSMSoliderMoveToTarget : FsmState<Solider>
{
    private Solider Solider_Enemy;
    private Transform targetTrans;
    protected override void OnInit(IFsm<Solider> fsm)
    {
        base.OnInit(fsm);
    }

    protected override void OnEnter(IFsm<Solider> fsm)
    {
        base.OnEnter(fsm);
        if (fsm.Owner.TargetObject)
        {
            targetTrans = fsm.Owner.TargetObject.transform;
            fsm.Owner.ChangeAnimatorState(Solider.State.Moving);
            fsm.Owner.MoveToTarget(targetTrans.position);
        }
    }

    protected override void OnLeave(IFsm<Solider> fsm, bool isShutdown)
    {
        base.OnLeave(fsm, isShutdown);
        targetTrans = null;
    }

    protected override void OnUpdate(IFsm<Solider> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        if (fsm.Owner)
        {
            // if (fsm.Owner.IsCanAttackEnemy())
            // {
            //     
            //     ChangeState<FSMSoliderAttack>(fsm);
            // }
        }
    }

    protected override void OnDestroy(IFsm<Solider> fsm)
    {
        base.OnDestroy(fsm);
    }
}