using GameFramework;
using GameFramework.Event;
using Script.Game.Base;

public class BattleClickPlayerTownEventArgs : GameEventArgs
{
    public static readonly int EventId = typeof(BattleClickPlayerTownEventArgs).GetHashCode();
    
    public static BattleClickPlayerTownEventArgs Create(Town town)
    {
        BattleClickPlayerTownEventArgs battleClickPlayerTown = ReferencePool.Acquire<BattleClickPlayerTownEventArgs>();
        battleClickPlayerTown.Town = town;
        return battleClickPlayerTown;
    }

    private Town town;
    
    public Town Town { get; set; }
    
    public override int Id { get {return EventId;} }
    public override void Clear() { }
}

public class BattleClickTargetTownEventArgs : GameEventArgs
{
    public static readonly int EventId = typeof(BattleClickTargetTownEventArgs).GetHashCode();
    
    public static BattleClickTargetTownEventArgs Create(Town town)
    {
        BattleClickTargetTownEventArgs battleClickTargetTown = ReferencePool.Acquire<BattleClickTargetTownEventArgs>();
        battleClickTargetTown.Town = town;
        return battleClickTargetTown;
    }

    private Town town;
    
    public Town Town { get; set; }
    
    public override int Id { get {return EventId;} }
    public override void Clear() { }
}

public class BattleClickTargetTownRetreatEventArgs : GameEventArgs
{
    public static readonly int EventId = typeof(BattleClickTargetTownRetreatEventArgs).GetHashCode();
    
    public static BattleClickTargetTownRetreatEventArgs Create(Town town)
    {
        BattleClickTargetTownRetreatEventArgs battleClickTargetTown = ReferencePool.Acquire<BattleClickTargetTownRetreatEventArgs>();
        battleClickTargetTown.Town = town;
        return battleClickTargetTown;
    }

    private Town town;
    
    public Town Town { get; set; }
    
    public override int Id { get {return EventId;} }
    public override void Clear() { }
}

//玩家点击位置是非UI区域
public class TouchClickNotUIEventArgs : GameEventArgs
{
    public static readonly int EventId = typeof(TouchClickNotUIEventArgs).GetHashCode();
    
    public static TouchClickNotUIEventArgs Create()
    {
        TouchClickNotUIEventArgs touchClickNotUI = ReferencePool.Acquire<TouchClickNotUIEventArgs>();
        return touchClickNotUI;
    }
    
    public override int Id { get {return EventId;} }
    public override void Clear() { }
}

//游戏开始事件
public class GameStartEventArgs : GameEventArgs
{
    public static readonly int EventId = typeof(GameStartEventArgs).GetHashCode();
    
    public static GameStartEventArgs Create()
    {
        GameStartEventArgs gameStartEventArgs = ReferencePool.Acquire<GameStartEventArgs>();
        return gameStartEventArgs;
    }
    
    public override int Id { get {return EventId;} }
    public override void Clear() { }
}