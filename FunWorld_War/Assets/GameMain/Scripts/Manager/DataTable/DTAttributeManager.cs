//属性类型
public enum  AttrType
{
    Fix     = 1,  //固定值
    Percent = 2,  //百分比
}

public enum AttrKey
{
    Att          = 1001,
    Hp           = 1002,
    Speed        = 1003,
    Vision       = 1004,
    Att_ExtraPer = 2001,
    Hp_ExtraPer  = 2002,
}

public class DTAttributeManager : DTBaseManager<DRAttribute>
{
    public override void Initialize()
    {
        DataTable = GameEntry.DataTable.GetDataTable<DRAttribute>();
    }

    public AttrType GetAttrType(int id)
    {
        return (AttrType)DataTable.GetDataRow(id).Type;
    }

    public AttrType GetAttrType(string attrName)
    {
        var data = DataTable.GetAllDataRows();
        foreach (var dataItem in data)
        {
            if (dataItem.ValueName == attrName)
            {
                return (AttrType)dataItem.Type;
            }
        }
        return AttrType.Fix;
    }
}