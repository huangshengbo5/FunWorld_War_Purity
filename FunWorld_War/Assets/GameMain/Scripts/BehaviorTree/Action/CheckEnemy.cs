using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class CheckEnemy : Action
    {
        //目标
        public SharedTransform InOut_TargetTrans;

        private Solider selfSolider;
        
        public override void OnAwake()
        {
            base.OnAwake();
            selfSolider = Owner.GetComponent<Solider>();
        }

        public override TaskStatus OnUpdate()
        {
            base.OnStart();
            
            if (InOut_TargetTrans != null && InOut_TargetTrans.Value != null)
            {
                var objectBase = InOut_TargetTrans.Value.GetComponent<BaseObject>();
                if (objectBase)
                {
                    if (objectBase.ObjectType() == ObjectType.Solider)
                    {
                        var enemySolider = objectBase.transform.GetComponent<Solider>();
                        if (!enemySolider.IsDead())
                        {
                            return TaskStatus.Success;
                        }
                    }  
                }
            }
            
            //主动寻找敌方士兵，优先自己寻找视野范围内目标
            var ViewRedius = selfSolider.ViewRedius;
            RaycastHit hit = new RaycastHit();
            Collider[] hits = new Collider[]{};
            hits = Physics.OverlapSphere(this.transform.position, ViewRedius);
            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    var tempSolider = hits[i].GetComponent<Solider>();
                    if (tempSolider && tempSolider.CampType != selfSolider.CampType)
                    {
                        if (tempSolider.TargetObject == null)
                        {
                            selfSolider.ChangeTargetObject(tempSolider);
                            return TaskStatus.Success;
                        }
                    }
                }
            }

            var targetSolider = selfSolider.FindEnemy();
            if (targetSolider != null)
            {
                selfSolider.ChangeTargetObject(targetSolider);
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}