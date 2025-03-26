using System;
using EGamePlay;
using GameFramework.ObjectPool;
using UnityEngine;

public class BaseObject :  MonoBehaviour
{
    //todo 需要删除
    public int MaxHp;
    //血量
    protected int CurHp;
    
    private long Id;
    [HideInInspector]
    public long ID 
    {
        get { return Id; }
    }

    private void Awake()
    {
        Id = IdFactory.NewInstanceId();
    }
    
    public virtual ObjectType ObjectType()
    {
        return global::ObjectType.None;
    }

    public virtual Vector3 GetInteractPoint()
    {
        return transform.position;
    }
}