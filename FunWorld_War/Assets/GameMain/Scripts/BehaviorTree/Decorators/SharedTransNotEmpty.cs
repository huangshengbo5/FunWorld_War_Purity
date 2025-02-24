using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class SharedTransNotEmpty : Decorator
    {
        public SharedTransform In_SharedTrans;

        //todo 无法主动相应变化
        public override bool CanExecute()
        {
            var isCanExe = In_SharedTrans != null && In_SharedTrans.Value != null;
            return isCanExe;
        }
        
        public override TaskStatus OverrideStatus()
        {
            Debug.Log("SharedTransNotEmpty TaskStatus OverrideStatus()");
            if (!CanExecute()) {
                return TaskStatus.Failure;
            }
            return TaskStatus.Running;
        }
    }
}