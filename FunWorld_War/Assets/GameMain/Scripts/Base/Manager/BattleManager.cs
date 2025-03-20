using Sirenix.Utilities.Editor;
using UnityEngine.PlayerLoop;

public class BattleManager
{
    private static BattleManager instace;
    public static BattleManager Instance()
    {
        if (instace == null) { instace = new BattleManager(); }
        return instace;
    }
    public FactoryManager Factory;

    public void Initialize()
    {
        Factory = new FactoryManager();
        Factory.Initialize();
    }
}