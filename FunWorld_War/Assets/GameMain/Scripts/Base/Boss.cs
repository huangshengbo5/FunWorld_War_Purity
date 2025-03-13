using System;
using EGamePlay;
using EGamePlay.Combat;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public CombatEntity CombatEntity;


    private void Start()
    {
        CombatEntity = CombatContext.Instance.AddChild<CombatEntity>();
        var ExecutionLinkPanelObj = GameObject.Find("ExecutionLinkPanel");
        if (ExecutionLinkPanelObj != null)
        {
            ExecutionLinkPanelObj.GetComponent<ExecutionLinkPanel>().BossEntity = CombatEntity;
        }
    }
}