using System.Collections;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class MoveToTarget : Action
    {
        //目标
        public SharedTransform targetTrans; 
        
        //距离目标多远停止
        public float stoppingDistance = 2f;
        
        //延迟时间
        public float delay; 
        
        private NavMeshAgent nav;
        private Solider selfSolider;

        public override void OnAwake()
        {
            base.OnAwake();
            nav = Owner.GetComponent<NavMeshAgent>();
            selfSolider = Owner.GetComponent<Solider>();
        }

        public override void OnStart()
        {
            base.OnStart();
            
            if (targetTrans != null && targetTrans.Value != null)
            {
                var targetObject = targetTrans.Value.GetComponent<BaseObject>();
               
                var targetPos = targetObject.GetInteractPoint();
                // 检查代理是否在 NavMesh 上
                if (!NavMesh.SamplePosition(selfSolider.transform.position, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
                {
                    Debug.LogWarning("Agent is not on NavMesh.");
                    return;
                }
                
                NavMeshPath path = new NavMeshPath();
                NavMesh.CalculatePath(selfSolider.transform.position, targetPos, NavMesh.AllAreas, path);
                if (path.status == NavMeshPathStatus.PathComplete && path.corners.Length > 0 && nav.isOnNavMesh == true) 
                {
                    nav.isStopped = false;
                    nav.SetDestination(targetPos);
                    selfSolider.ChangeState(Solider.State.Moving);
                }
                else
                {
                    Debug.LogError($"targetPos:{targetPos} 无法导航到达！！！");
                }
            }
            else
            {
                nav.isStopped = true;
            }
            nav.stoppingDistance = selfSolider.AttackRedius;
            
            //StartCoroutine(DelayMove());
        }

        private IEnumerator DelayMove()
        {
            yield return new WaitForSeconds(delay);
            if (targetTrans != null && targetTrans.Value != null)
            {
                var targetObject = targetTrans.Value.GetComponent<Town>();
                nav.isStopped = false;
                nav.SetDestination(targetObject.GetInteractPoint());
                selfSolider.ChangeState(Solider.State.Moving);
            }
            else
            {
                nav.isStopped = true;
            }
            nav.stoppingDistance = selfSolider.AttackRedius;
        }

        public override TaskStatus OnUpdate()
        {
            var isStop = CheckDestinationReached(nav);
            return isStop ? TaskStatus.Success : TaskStatus.Running;
        }

        public bool CheckDestinationReached(NavMeshAgent agent)
        {
            if (agent.hasPath)
            {
                if (agent.remainingDistance <= selfSolider.AttackRedius)
                {
                    return true;
                }
            }
            return false;
        }
    }
}