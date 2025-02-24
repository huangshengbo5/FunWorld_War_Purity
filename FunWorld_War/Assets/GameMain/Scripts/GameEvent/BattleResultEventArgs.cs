using GameFramework;
using GameFramework.Event;

public class BattleResultEventArgs : GameEventArgs
{
    public static readonly int EventId = typeof(BattleResultEventArgs).GetHashCode();
    
    public BattleResultType BattleResult;
    
    public static BattleResultEventArgs Create(BattleResultType battleResultType)
    {
        BattleResultEventArgs battleResultEventArgs = ReferencePool.Acquire<BattleResultEventArgs>();
        battleResultEventArgs.BattleResult = battleResultType;
        return battleResultEventArgs;
    }
    
    public override int Id { get { return EventId; } }
    
    public override void Clear() { }
}