using GameFramework;
using GameFramework.ObjectPool;
using UnityEngine;

public class SoliderPoolItem : ObjectBase
{
    public static SoliderPoolItem Create(object target)
    {
        SoliderPoolItem solider = ReferencePool.Acquire<SoliderPoolItem>();
        solider.Initialize(target);
        return solider;
    }
    protected override void Release(bool isShutdown)
    {
        Solider solider = (Solider)Target;
        if (!solider)
        {
            return;
        }
        Object.Destroy(solider.gameObject);
    }
}