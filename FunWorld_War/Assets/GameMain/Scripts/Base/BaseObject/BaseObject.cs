using System;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    public int MaxHp;
    private int Id;
    //血量
    protected int CurHp;
    
    
    [HideInInspector]
    public int ID 
    {
        get { return Id; }
    }

    private void Awake()
    {
        Id = gameObject.GetHashCode();
    }
    
    public virtual Vector3 GetInteractPoint(Vector3 position = new Vector3())
    {
        return transform.position;
    }
    
    public virtual ObjectType ObjectType()
    {
        return global::ObjectType.None;
    }
    
    public virtual void BeAttack(BaseObject attacker, int damageNum) { }
    public virtual void OnClick(){}
}