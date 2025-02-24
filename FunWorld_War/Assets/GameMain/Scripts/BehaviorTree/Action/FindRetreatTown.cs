namespace BehaviorDesigner.Runtime.Tasks
{
    public class FindRetreatTown : Action
    {
        private Solider Solider;
        
        //目标
        public SharedTransform InOut_TargetTrans;
        
        public override void OnAwake()
        {
            base.OnAwake();
        }

        public override void OnStart()
        {
            base.OnStart();
            Solider = Owner.GetComponent<Solider>();
            var ownerTown = Solider.OwnerTown;
            if (ownerTown.Camp() == Solider.CampType)
            {
                InOut_TargetTrans.SetValue(ownerTown.transform);
            }
            else
            {
                var gameMode =  Common.CurGameMode() as GameMode_Survival;
                if (gameMode == null)
                {
                    return;
                }
                var towns = gameMode.AllBattleTowns;
                foreach (var town in towns)
                {
                    if (town.Camp() == Solider.CampType)
                    {
                        InOut_TargetTrans.SetValue(town.transform);
                        break;
                    }
                }
            }
        }
    }
}