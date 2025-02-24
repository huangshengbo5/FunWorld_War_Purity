using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using GameFramework.Resource;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(BehaviorTree))]
public partial class Solider : BaseObject
{
    private int soliderId;

    public int SoliderId
    {
        get => soliderId;
        set => soliderId = value;
    }
    
    private CampType campType;

    public CampType CampType
    {
        get => campType;
        set => campType = value;
    }

    public State curState;   //当前的单位状态
    
    public int ViewRedius;   //视野半径
    public int AttackRedius;  //攻击半径
    
    private Animator Animator;
    
    protected BaseObject targetObject;
    
    //士兵归属的城镇
    protected Town ownerTown;
    
    public BaseObject TargetObject
    {
        get
        {
            return this.targetObject;
        }
    }

    public Town OwnerTown
    {
        get
        {
            return this.ownerTown;
        }
        set
        {
            this.ownerTown = value;
        }
    }
    
    private NavMeshAgent navMeshAgent;
    
    //伤害数值
    public int Damage;
    
    //造成伤害时间间隔信息
    private float AttackTimeStamp;
    private float AttackInterval = 1;

    private bool retreat;
    private BehaviorTree behaviorTree;

    private bool isKill;
    //归属的部队
    private SoliderCommander ownerSoliderCommander;

    public SoliderHUD soliderHUD;


    public SoliderCommander OwnerSoliderCommander
    {
        get => ownerSoliderCommander;
        set => ownerSoliderCommander = value;
    }

    public override ObjectType ObjectType()
    {
        return global::ObjectType.Solider;
    }

    public void Init()
    {
        CurHp = MaxHp;
        InitBehaviorTree();
        InitComponent();
        isKill = false;
        soliderHUD.Init(this);
        soliderHUD.UpdatgeHP(CurHp,MaxHp);
    }
    
    //初始化组件信息
    void InitComponent()
    {
        var model = this.transform.Find("Model");
        var childNum = model.childCount;
        if (childNum == 0 || childNum > 1)
        {
            Debug.LogError($"gameobject.name:{this.gameObject.name} Model Num is Error");
        }
        var ani = model.GetChild(0);
        Animator = ani.transform.GetComponent<Animator>();
        if (!Animator)
        {
            Animator = ani.transform.AddComponent<Animator>();
        }

        navMeshAgent = transform.GetComponent<NavMeshAgent>();
    }

    public void Init_SoliderCommander(SoliderCommander soliderCommander)
    {
        if (OwnerSoliderCommander != soliderCommander)
        {
            OwnerSoliderCommander = soliderCommander;
        }
        else
        {
            Debug.LogError("OwnerSoliderCommander == soliderCommander!");
        }
    }
    
    public void InitBehaviorTree()
    {
        behaviorTree= this.gameObject.GetComponent<BehaviorTree>();
        ExternalBehavior externalBehavior;
        BehaviorTreeEnum behaviorTreeEnum;
        switch (campType)
        {
            case CampType.Player:
                behaviorTreeEnum = BehaviorTreeEnum.Player;
                break;
            case CampType.Neutral:
                behaviorTreeEnum = BehaviorTreeEnum.Neutral;
                break;
            default:
                behaviorTreeEnum = BehaviorTreeEnum.Neutral;
                break;
        }
        var behaviorPath = AssetUtility.GetBehaviorAsset(Common.GetBehaviorTreePath(behaviorTreeEnum));
        var  m_LoadAssetCallbacks = new LoadAssetCallbacks((string assetName,object asset,float duration,object userData)=>
        {
            externalBehavior = asset as ExternalBehavior;
            behaviorTree.ExternalBehavior = externalBehavior;
        }, null, null, null);
        GameEntry.Resource.LoadAsset(behaviorPath, m_LoadAssetCallbacks);
    }
    
    public enum State
    {
        Idleing,      //休闲
        Moving,       //移动
        Attack_Enemy,  //攻击敌人
        Dead,          //死亡
    }
    
    public void ChangeTargetObject(BaseObject targetTown)
    {
        targetObject = targetTown;
        behaviorTree.SetVariableValue("TargetTrans",targetObject ? targetObject.transform : null);
    }
    
    public BaseObject GetTargetObject()
    {
        return this.targetObject;
    }

    public void SufferInjure(float injure)
    {
        throw new System.NotImplementedException();
    }

    public void SufferInjure(int injure)
    {
        CurHp -= injure;
        soliderHUD.UpdatgeHP(CurHp,MaxHp);
    }
    
    public void DoAttack()
    {
        ChangeAnimatorState(State.Attack_Enemy);
    }

    public void ChangeState(State state)
    {
        ChangeAnimatorState(state);
    }

    public void Retreat()
    {
        StartCoroutine(DelayRetreat());
    }
    
    public IEnumerator  DelayRetreat()
    {
        if (!IsDead())
        {
            behaviorTree.SetVariableValue("Retreat",true);
            var targetTrans = behaviorTree.GetVariable("TargetTrans");
            retreat = true;
            yield return new WaitUntil(() =>
            {
                if (IsReachPosition((Transform)targetTrans.GetValue()))
                {
                       EnterTown();
                       return true;
                }
                return false;
            });
        }
    }

    public bool IsReachPosition(Transform trans)
    {
        return Vector3.Distance(transform.position, trans.position) < AttackRedius;
    }
    

    public void OnAttackHited()
    {
        if (targetObject is Solider)
        {
            var targetSolider = targetObject as Solider;
            if (!targetSolider.IsDead())
            {
                targetSolider.BeAttack(this,this.Damage);
            }
            else
            {
                ChangeTargetObject(null);
            }
        }
        else if (targetObject is Town)
        {
            var targetTown = targetObject as Town;
            if (targetTown.IsOccupied == false)
            {
                targetTown.BeAttack(this,this.Damage);
            }
        }
    }
    
    public bool IsDead()
    {
        return curState == State.Dead;
    }

    //被攻击
    public override void BeAttack(BaseObject attacker, int damageNum)
    {
        if (isKill)
        {
            return;
        }
        SufferInjure(damageNum);
        if (CurHp <= damageNum || CurHp < 0)
        {
            if (ChangeAnimatorState(State.Dead))
            {
                isKill = true;
                StartCoroutine(DeadSuccess());
            }
        }
        else if (targetObject == null || targetObject != attacker)
        {
            ChangeTargetObject(attacker);
        }
    }

    protected IEnumerator DeadSuccess()
    {
        ownerSoliderCommander.RemoveSolider(this);
        behaviorTree.OnDestroy();
        behaviorTree = null;
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
        Debug.LogWarning($"士兵：{this.gameObject.name},死亡");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,ViewRedius);
    }

    //改变装填
    public bool ChangeAnimatorState(State state)
    {
        if (curState == state)
        {
            return false;
        }
        ResetAniState();
        switch (state)
        {
            case State.Moving:
                Animator.SetBool("Move",true);
                break;
            case State.Idleing:
                Animator.SetBool("Idle",true);
                break;
            case State.Dead:
                Animator.SetTrigger("Dead");
                break;
            default:
                Animator.SetBool("Attack",true);
                break;
        }
        curState = state;
        return true;
    }

    protected void ResetAniState()
    {
        Animator.SetBool("Move",false);
        Animator.SetBool("Idle",false);
        Animator.SetBool("Attack",false);
    }
    
    public void MoveToTarget(Vector3 targetPoint)
    {
        ChangeAnimatorState(State.Moving);
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(targetPoint);
        navMeshAgent.stoppingDistance = 2;
    }

    //进城，攻城成功或者守城成功
    public void EnterTown()
    {
        ChangeAnimatorState(State.Moving);
        Debug.Log("士兵进城！！！");
        behaviorTree.OnDestroy();
        behaviorTree = null;
        this.gameObject.SetActive(false);
    }

    public BaseObject FindEnemy()
    {
        return OwnerSoliderCommander.SoliderFindTarget(this);
    }
}