using System.Collections.Generic;

public class DTNPCManager : DTBaseManager<DRNPC>
{
    public override void Initialize()
    {
        DataTable = GameEntry.DataTable.GetDataTable<DRNPC>();
    }
    
    /// <summary>
    /// 获取所有属性信息
    /// </summary>
    /// <param name="npcId"></param>
    /// <returns>List<string></returns>
    public List<string> GetAllAvalue(int npcId)
    {
        List<string> skillList = new List<string>();
        var dtNPC = DataTable.GetDataRow(npcId);
        skillList.Add(dtNPC.avalue_base);
        skillList.Add(dtNPC.avalue_senior);
        return skillList;
    }
}