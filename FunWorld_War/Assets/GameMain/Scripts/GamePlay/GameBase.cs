//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;


public abstract class GameBase
{
    public abstract GameMode GameMode { get; }


    public bool GameOver { get; protected set; }

    public virtual void Initialize()
    {
        GameOver = false;
        GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
        GameEntry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);

    }

    public virtual void Shutdown()
    {
        GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
        GameEntry.Event.Unsubscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);
    }

    public virtual void Update(float elapseSeconds, float realElapseSeconds)
    {
        GameOver = true;
        return;
    }

    protected virtual void OnShowEntitySuccess(object sender, GameEventArgs e)
    {
        var ne = (ShowEntitySuccessEventArgs)e;
    }

    protected virtual void OnShowEntityFailure(object sender, GameEventArgs e)
    {
        var ne = (ShowEntityFailureEventArgs)e;
        Log.Warning("Show entity failure with error message '{0}'.", ne.ErrorMessage);
    }
}