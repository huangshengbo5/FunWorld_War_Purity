
using UnityEngine;

public static class Commmon_Color
{
        public static Color HPBarColor(BaseObject baseObject, CampType campType)
        {
                if (baseObject is Solider)
                {
                        switch (campType)
                        {
                                case CampType.Neutral:
                                        return Color.yellow;
                                case CampType.Player:
                                case CampType.OtherPlayer:
                                        return Color.green;
                                default:
                                        return Color.red;
                        }
                }
                else if (baseObject is Town)
                {
                        return Color.blue;
                }
                return Color.black;
        }
}