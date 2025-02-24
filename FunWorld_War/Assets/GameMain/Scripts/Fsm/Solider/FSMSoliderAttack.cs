using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using UnityEngine;

public class FSMSoliderAttack : FsmState<Solider>
{
    protected override void OnInit(IFsm<Solider> fsm)
    {
        base.OnInit(fsm);
    }

    protected override void OnEnter(IFsm<Solider> fsm)
    {
        base.OnEnter(fsm);
        fsm.Owner.transform.LookAt(fsm.Owner.TargetObject.transform.position);
        fsm.Owner.ChangeAnimatorState(Solider.State.Attack_Enemy);
    }

    protected override void OnLeave(IFsm<Solider> fsm, bool isShutdown)
    {
        base.OnLeave(fsm, isShutdown);
    }

    protected override void OnUpdate(IFsm<Solider> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        //if (fsm.Owner.TargetObject && fsm.Owner.TargetObject.IsDead() == false) 
        {
            fsm.Owner.DoAttack();
        }
    }

    protected override void OnDestroy(IFsm<Solider> fsm)
    {
        base.OnDestroy(fsm);
    }
}