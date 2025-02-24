namespace BehaviorDesigner.Runtime.Tasks
{
    public class Solider_ChangeState : Action
    {
        public Solider.State state;
        private Solider Solider;
        public override void OnAwake()
        {
            base.OnAwake();
            Solider = Owner.GetComponent<Solider>();
        }

        public override void OnStart()
        {
            base.OnStart();
            Solider.ChangeState(state);
        }
    }
}