public partial class Solider
{ 
    private Attribute Attribute;

    public void Init_Attribute()
    {
        Attribute = new Attribute();

        //var allAvalue = GameEntry.DTManager.DTNPCManager.GetAllAvalue();
        var npc = GameEntry.DataTable.GetDataTable<DRNPC>();
        //var npcConfig = GameEntry.DTManager.DTNPCManager
    }

    public void Add_Attribute()
    {
        //Attribute.AddAttribute();
    }
}