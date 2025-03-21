using System;
using System.Collections;
using EGamePlay;
using EGamePlay.Combat;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public CombatEntity CombatEntity;


    private void Start()
    {
        StartCoroutine(DelayInit());
    }

    IEnumerator DelayInit()
    {
        yield return new WaitUntil(() =>
        {
            return CombatContext.Instance != null;
        });
        CombatEntity = CombatContext.Instance.AddChild<CombatEntity>();
        var ExecutionLinkPanelObj = GameObject.Find("ExecutionLinkPanel");
        if (ExecutionLinkPanelObj != null)
        {
            ExecutionLinkPanelObj.GetComponent<ExecutionLinkPanel>().BossEntity = CombatEntity;
        }
    }
    
}