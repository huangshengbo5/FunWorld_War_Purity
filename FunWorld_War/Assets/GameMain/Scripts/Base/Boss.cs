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
        CombatContext.Instance.Object2Entities.Add(gameObject, CombatEntity);
        var ExecutionLinkPanelObj = GameObject.Find("ExecutionLinkPanel");
        if (ExecutionLinkPanelObj != null)
        {
            ExecutionLinkPanelObj.GetComponent<ExecutionLinkPanel>().BossEntity = CombatEntity;
        }
        CombatEntity.ListenActionPoint(ActionPointType.PostReceiveDamage, OnReceiveDamage);
    }
    private void OnReceiveDamage(Entity combatAction)
    {
        var damageAction = combatAction as DamageAction;
        //var  CombatEntity.CurrentHealth.ToPercent();
        print($"Boss ReciveDamage:{damageAction.DamageValue}");
        // HealthBarImage.fillAmount =  CombatEntity.CurrentHealth.ToPercent();
        // var damageText = GameObject.Instantiate(DamageText);
        // damageText.transform.SetParent(CanvasTrm);
        // damageText.transform.localPosition = Vector3.up * 120;
        // damageText.transform.localScale = Vector3.one;
        // damageText.transform.localEulerAngles = Vector3.zero;
        // damageText.text = $"-{damageAction.DamageValue}";
        // damageText.GetComponent<DOTweenAnimation>().DORestart();
        // GameObject.Destroy(damageText.gameObject, 0.5f);
    }
}