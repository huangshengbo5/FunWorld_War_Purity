using System.Collections.Generic;

public class Attribute 
{
    // private float Hp;
    // private float Hp_Percent;
    // public float Hp_Cur;   //当前血量
    // public float Hp_Max;
    //
    // private float Atk;
    // private float Atk_Percent;
    // public float Atk_Cur;  //当前攻击力
    //
    // private float Damage_Cur; //当前伤害值
    // public float Speed_Cur; //当前速度
    //
    // public float Vision;  //当前视野

    
    private Dictionary<string, float> dic_Attr;
    public Attribute()
    {
        dic_Attr = new Dictionary<string, float>();
    }

    //添加属性配置
    public bool AddAttribute(string attrs)
    {
        if (attrs.Equals(string.Empty))
        {
            return false;
        }
        if (dic_Attr == null)
        {
            dic_Attr = new Dictionary<string, float>();
        }
        attrs.Trim();
        attrs.TrimStart();
        attrs.TrimEnd();
        var attrsStr = attrs.Split(';');
        for (int i = 0; i < attrsStr.Length; i++)
        {
            var singleAttr = attrsStr[i];
            var singleAttrStr = singleAttr.Split(',');
            if (singleAttrStr.Length < 2)
            {
                return false;
            }
            string AttrKey = singleAttrStr[0];
            float AttrValue = 0f;
            if (!float.TryParse(singleAttrStr[1],out AttrValue))
            {
                return false;
            }
            if (!dic_Attr.ContainsKey(AttrKey))
            {
                dic_Attr[AttrKey] = 0;
            }
            dic_Attr[AttrKey] += AttrValue;
        }
        return true;
    }

    public Dictionary<string, float> GetAttrs()
    {
        return dic_Attr;
    }

    public float GetSpeed()
    {
        float speed_Fix = 0f;
        if (dic_Attr.TryGetValue(AttrKey.Speed.ToString(),out speed_Fix))
        {
            return speed_Fix;
        }
        return speed_Fix;
    }
    
    public float GetVision()
    {
        float vision_Fix = 0f;
        if (dic_Attr.TryGetValue(AttrKey.Vision.ToString(),out vision_Fix))
        {
            return vision_Fix;
        }
        return vision_Fix;
    }

    //获取攻击力
    public float GetAtt()
    {
        float att_Fix = 0f;
        if (dic_Attr.TryGetValue(AttrKey.Att.ToString(),out att_Fix))
        {
            float att_Per = 0f;
            if (dic_Attr.TryGetValue(AttrKey.Att_ExtraPer.ToString(),out att_Per))
            {
                att_Fix += att_Fix * (1 + att_Per / 10000);
            }
        }
        return att_Fix;
    }
    
    //获取血量
    public float GetHp()
    {
        float hp_Fix = 0f;
        if (dic_Attr.TryGetValue(AttrKey.Hp.ToString(),out hp_Fix))
        {
            float hp_Per = 0f;
            if (dic_Attr.TryGetValue(AttrKey.Hp_ExtraPer.ToString(),out hp_Per))
            {
                hp_Fix += hp_Fix * (1 + hp_Per / 10000);
            }
        }
        return hp_Fix;
    }
}