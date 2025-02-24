using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class TargetIsSolider : Decorator
    {
        public SharedTransform In_TargetTrans;

        public override bool CanExecute()
        {
            var town = In_TargetTrans.Value;
            Solider solider;
            if (town.TryGetComponent<Solider>(out solider))
            {
                return true;
            }
            return false;
        }
    }
}