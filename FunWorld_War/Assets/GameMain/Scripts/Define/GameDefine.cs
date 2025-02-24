//城市的阵营
public enum CampType
{
    None        ,   //无
    Player      ,   //玩家
    AI_Red      ,   //对手AI1
    AI_Blue     ,   //对手AI2
    AI_Green    ,   //对手AI3
    AI_White    ,   //对手AI4
    AI_Black    ,   //对手AI5
    OtherPlayer ,   //其他玩家
    Neutral     ,   //中立
}

public enum RelationType
{
    Hostile , //敌人
    Friend  , //好友
}

public enum ObjectType
{
    None   ,
    Town   , //城池
    Solider, //士兵
}