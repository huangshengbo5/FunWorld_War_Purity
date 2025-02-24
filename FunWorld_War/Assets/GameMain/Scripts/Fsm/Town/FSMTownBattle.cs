using GameFramework.Fsm;
using Script.Game.Base;
using UnityEngine;

public class FSMTownBattle : FsmState<Town>
{
    protected override void OnInit(IFsm<Town> fsm)
    {
        base.OnInit(fsm);
    }

    protected override void OnEnter(IFsm<Town> fsm)
    {
        base.OnEnter(fsm);
        //fsm.Owner.JoinBattle(fsm.Owner.GetAllSoliders());   //??????????
    }

    protected override void OnUpdate(IFsm<Town> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        var result = fsm.Owner.CheckBattleResult();
        if (result.Item1)
        {
            ChangeState<FSMTownBattleEnd>(fsm);
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