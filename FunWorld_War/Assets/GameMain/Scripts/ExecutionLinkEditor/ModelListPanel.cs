using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using Unity.VisualScripting;

namespace EGamePlay
{
    public class ModelListPanel : MonoBehaviour
    {
        public static ModelListPanel Instance { get; set; }
        public Transform ContentTrm;
        public Button SkillBtn;
        public Button PopupBtn;
        public Button RefreshBtn;


        private void Start()
        {
            Instance = this;
            SkillBtn.transform.SetParent(null);
            RefreshList();
            PopupBtn.onClick.AddListener(Popup);
            RefreshBtn.onClick.AddListener(RefreshList);
        }

        public void Popup()
        {
            var p = transform.rectTransform().anchoredPosition;
            if (p.x > 1)
            {
                transform.rectTransform().anchoredPosition = new Vector2(0, p.y);
            }
            else
            {
                transform.rectTransform().anchoredPosition = new Vector2(transform.rectTransform().sizeDelta.x, p.y);
            }
        }

        public void RefreshList()
        {
            
#if UNITY_EDITOR
            ContentTrm.DestroyChildren();

            var modelConfig = GameEntry.DataTable.GetDataTable<DRModel>();
            var modelConfigs = modelConfig.GetAllDataRows();
            foreach (var config in modelConfigs)
            {
                 var btn = Instantiate(SkillBtn.gameObject, ContentTrm);
                 btn.GetComponentInChildren<Text>().text = config.Id.ToString();
                 
                 btn.GetComponent<Button>().onClick.AddListener(() =>
                 {
                     var solider = BattleManager.Instance().Factory.Solider.Create(new SoliderFactory.SoliderConfig
                         (config.Id,
                             new Vector3(0,0,0),
                             Vector3.one
                             ));
                 });
            }
            var listTrm = ContentTrm;
            var itemTrm = SkillBtn.transform;
            var trackListSize = listTrm.rectTransform().sizeDelta;
            var space = listTrm.GetComponent<VerticalLayoutGroup>().spacing;
            listTrm.rectTransform().sizeDelta = new Vector2(trackListSize.x, listTrm.childCount * (itemTrm.rectTransform().sizeDelta.y + space));
#endif
        }
    }
}
