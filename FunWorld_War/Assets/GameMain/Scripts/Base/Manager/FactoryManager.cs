public class FactoryManager
{
    public SoliderFactory Solider;

    public void Initialize()
    {
        Solider = new SoliderFactory();
        Solider.Initialization();
    }
}