using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class InitSoliderProperty : Action
    {
        public SharedTransform targetTown;

        public override void OnAwake()
        {
            base.OnAwake();
            var solider = Owner.GetComponent<Solider>();
            targetTown.SetValue(solider.GetTargetObject().transform);
        }
    }
}