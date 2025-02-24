namespace BehaviorDesigner.Runtime.Tasks
{
    public class RotateToTarget : Action
    {
        //目标
        public SharedTransform targetTrans; 
        private Solider selfSolider;

        public override void OnAwake()
        {
            base.OnAwake();
            selfSolider = Owner.GetComponent<Solider>();
        }
        
        public override TaskStatus OnUpdate()
        {
            selfSolider.transform.forward = targetTrans.Value.position - selfSolider.transform.position;
            return base.OnUpdate();
        }
    }
}