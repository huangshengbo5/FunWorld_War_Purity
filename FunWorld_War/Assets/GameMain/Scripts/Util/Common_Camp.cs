public static partial class Common
{
     public static string GetCampImagePath(CampType campType)
     {
          switch (campType)
          {
               case CampType.Neutral:
                    return "common/ui_qizhi_cheng";
                    break;
               case CampType.Player:
                    return "common/ui_qizhi_lan";
                    break;
               case CampType.OtherPlayer:
                    return "common/ui_qizhi_zi";
                    break;
          }
          return "common/ui_qizhi_hong";
     }
}