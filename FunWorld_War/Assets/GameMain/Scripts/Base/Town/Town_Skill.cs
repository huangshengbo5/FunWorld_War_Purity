using System.Collections;
using EGamePlay;
using EGamePlay.Combat;
using UnityEngine;

public partial class Town
{
    [HideInInspector]
    public CombatEntity CombatEntity;


    IEnumerator DelayStart_Skill()
    {
        yield return new WaitUntil(() =>
        {
            return CombatContext.Instance != null;
        });
        Start_Skill();
    }
    public void Start_Skill()
    {
        CombatEntity = CombatContext.Instance.AddChild<CombatEntity>();
        CombatContext.Instance.Object2Entities.Add(gameObject, CombatEntity);
        CombatEntity.IsHero = false;
        CombatEntity.CampType = campType;
        //CombatEntity.HeroObject = gameObject;
        CombatEntity.ModelTrans = gameObject.transform;
        CombatEntity.ListenActionPoint(ActionPointType.PostReceiveDamage, OnReceiveDamage);
        CombatEntity.CurrentHealth.Minus(30000);
    }

    private void OnReceiveDamage(Entity combatAction)
    {
        var damageAction = combatAction as DamageAction;
        if (IsOccupied == false)
        {
            var combatActionParent = (CombatEntity)combatAction.Parent;
            BeAttack(combatActionParent.HeroObject.GetComponent<BaseObject>(),1);
        }
        print($"Boss ReciveDamage:{damageAction.DamageValue}");
        // var damageAction = combatAction as DamageAction;
        // HealthBarImage.fillAmount = CombatEntity.CurrentHealth.ToPercent();
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