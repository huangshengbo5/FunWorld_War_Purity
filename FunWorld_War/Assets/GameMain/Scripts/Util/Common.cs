public static partial class Common
{
     public static CampType GetBaseObjectCamp(this BaseObject baseObject)
     {
          if (baseObject is Solider)
          {
               var slider = baseObject as Solider;
               return slider.CampType;
          }
          else if(baseObject is Town)
          {
               var town = baseObject as Town;
               return town.Camp();
          }
          return CampType.None;
     }

     /// <summary>
     /// 当前的GameMode
     /// </summary>
     /// <returns></returns>
     public static GameBase CurGameMode()
     {
          var curProcedure = GameEntry.Procedure.CurrentProcedure;
          if (curProcedure is ProcedureMain)
          {
               var procedureMain =curProcedure as ProcedureMain; 
               GameBase curGameMode = procedureMain.CurGameMode();
               return curGameMode;
          }
          return null;
     }

     //获取阵营之间的关系
     public static RelationType GetRelation(CampType camp1,CampType camp2)
     {
          if (camp1 == camp2)
          {
               return RelationType.Friend;
          }
          return RelationType.Hostile;
     }

     public static string GetBehaviorTreePath(BehaviorTreeEnum behaviorTreeEnum)
     {
          switch (behaviorTreeEnum)
          {
               case BehaviorTreeEnum.Player:
                    return "BT_Solider_Player";
                    break;
               case BehaviorTreeEnum.Neutral:
                    return "BT_Solider_Neutral";
                    break;
          }
          return "BT_Solider_Player";
     }
}