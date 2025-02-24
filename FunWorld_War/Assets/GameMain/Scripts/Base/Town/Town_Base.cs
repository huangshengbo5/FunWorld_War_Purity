using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

    public partial class Town :BaseObject
    {
        public TownHUD TownHUD;
        //默认生成士兵数量
        public int DefaultMaxSoliderNum;

        public CampType ownerCamp = global::CampType.None;
        
        protected int curSoliderNum;

        public int CurSoliderNum
        {
            get => curSoliderNum;
            set
            {
                curSoliderNum = value;
                DelegateTownSoliderNumChange.Invoke(curSoliderNum,DefaultMaxSoliderNum);
            }
        }

        //目标城镇
        protected Town TargetTown;
        public int ViewRedius;  //视野范围
        private bool isOccupied;

        private List<Transform> SpawnerPoints;
        
        [HideInInspector]
        public UnityAction<CampType> DelegateTownCampChange;
        [HideInInspector]
        public UnityAction<int,int> DelegateTownHpChange;
        [HideInInspector]
        public UnityAction<int, int> DelegateTownSoliderNumChange;
        
        public bool IsOccupied
        {
            get => isOccupied;
            set => isOccupied = value;
        }
        
        public override ObjectType ObjectType()
        {
            return global::ObjectType.Town;
        }

        public CampType Camp()
        {
            return ownerCamp;
        }

        //被占领
        public void BeOccupied(CampType campType)
        {
            ownerCamp = campType;
            DelegateTownCampChange.Invoke(ownerCamp);
            ResetData();
        }
        
        public void Update()
        {
            List<Solider> enemySoliders;
            if (CheckHaveEnemyInView(out enemySoliders))
            {   
                SelfDefense();
            }
            if (this.townBattleJudge != null)
            {
                this.townBattleJudge.DoUpdate();    
            }
        }

        //进行自卫
        private void SelfDefense()
        {
            var soliderCommander = CreateSolider(this);
            if (soliderCommander != null)
            {
                Debug.Log("有敌人靠近，造兵进行自卫！！");
                JoinBattle(soliderCommander);
            }
        }
        
        //附近是否有把自己当作目标的部队
        private bool CheckHaveEnemyInView(out List<Solider> enemySoliders)
        {
            enemySoliders = new List<Solider>();
            RaycastHit hit = new RaycastHit();
            Collider[] hits = new Collider[]{};
            hits = Physics.OverlapSphere(this.transform.position, ViewRedius);
            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    var tempSolider = hits[i].GetComponent<Solider>(); 
                    if (tempSolider && tempSolider.CampType != this.Camp() && tempSolider.GetTargetObject() == this)
                    {
                        enemySoliders.Add(tempSolider);
                    }
                }
            }
            return enemySoliders.Count > 0;
        }
        
        public override Vector3 GetInteractPoint(Vector3 position)
        {
            if (SpawnerPoints == null || SpawnerPoints.Count == 0)
            {
                if (SpawnerPoints == null)
                {
                    SpawnerPoints = new List<Transform>();
                }
                SpawnerPoints.Clear();
                var spawnerHolder = gameObject.transform.Find("Spawner").gameObject;
                var childCount = spawnerHolder.transform.childCount;
                for (int i = 0; i < childCount; i++)
                {
                    SpawnerPoints.Add(spawnerHolder.transform.GetChild(i).transform);
                }
            }
            int index = Random.Range(0, SpawnerPoints.Count-1);
            return SpawnerPoints[1].position;
        }
        
        //被点击选中
        public override void OnClick()
        {
            if (ownerCamp == CampType.Player) //处理我方城池被选中逻辑
            {
                GameEntry.Event.Fire(this,BattleClickPlayerTownEventArgs.Create(this));
                //CreateClickUI_Player();
            }
            else
            {
                if (townBattleJudge.EnemySoliderCommandersContainPlayer())
                {
                    TownHUD.SwitchRetreatBtn(true);
                }
                //显示操作按钮UI
                TownHUD.SwitchEnterBtn();
            }
        }

        //TODO 逻辑不应该写在这，需要一个单独的场景中的所有城镇关系的管理类
        //敌对城镇显示操作UI
        public void EnemyTownShowOperateUI()
        {
            var gameMode = Common.CurGameMode();
            var gameMode_Survival = gameMode as GameMode_Survival;
            var hostileTowns = gameMode_Survival.GetHostileTown(this);
            foreach (var townItem in hostileTowns)
            {
                townItem.OnClick();
            }
        }
    }