using EGamePlay;
using EGamePlay.Combat;
using ET;
using GameFramework.Resource;
using UnityEngine;
using Log = EGamePlay.Log;

public partial class Solider
{
    [HideInInspector]
    public CombatEntity CombatEntity;
    [HideInInspector]
    public AnimationComponent AnimationComponent;

    public void Start_Skill()
    {
        CombatEntity = CombatContext.Instance.AddChild<CombatEntity>();
        CombatContext.Instance.Object2Entities.Add(gameObject, CombatEntity);
        CombatEntity.IsHero = true;
        CombatEntity.HeroObject = gameObject;
        CombatEntity.ModelTrans = gameObject.transform.GetChild(0);
        CombatEntity.ListenActionPoint(ActionPointType.PreSpell, OnPreSpell);
        CombatEntity.ListenActionPoint(ActionPointType.PostSpell, OnPostSpell);
        CombatEntity.ListenActionPoint(ActionPointType.PostReceiveDamage, OnReceiveDamage);
        CombatEntity.ListenActionPoint(ActionPointType.PostReceiveCure, OnReceiveCure);
        CombatEntity.ListenActionPoint(ActionPointType.PostReceiveStatus, OnReceiveStatus);
        CombatEntity.Subscribe<RemoveStatusEvent>(OnRemoveStatus);
        CombatEntity.Subscribe<AnimationClip>(OnPlayAnimation);
        CombatEntity.CurrentHealth.Minus(30000);
        

        //todo  加载技能配置
        var abilityConfig = GameEntry.DataTable.GetDataTable<DRAbilityConfig>();
        var enumerator = abilityConfig.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var abilityItem = enumerator.Current;
            var skillId = abilityItem.Id;
            var skillConfigObjectPath = $"Assets/GameMain/Ability/{AbilityManagerObject.SkillResFolder}/Skill_{skillId}.asset";
            var  m_LoadAssetCallbacks = new LoadAssetCallbacks((string assetName,object asset,float duration,object userData)=>
            {
                var ability = CombatEntity.GetComponent<SkillComponent>().AttachSkill(asset);
                if (!enumerator.MoveNext())
                {
                    CombatEntity.GetComponent<SpellComponent>().LoadExecutionObjects();
                }
            }, null, null, null);
            GameEntry.Resource.LoadAsset(skillConfigObjectPath, m_LoadAssetCallbacks);
        }
        // foreach (var abilityItem in abilityConfig)
        // {
        //     if (abilityItem.Type == (int)SkillType.Skill)
        //     {
        //         var skillId = abilityItem.Id;
        //         var skillConfigObjectPath = $"Assets/GameMain/Ability/{AbilityManagerObject.SkillResFolder}/Skill_{skillId}.asset";
        //         var  m_LoadAssetCallbacks = new LoadAssetCallbacks((string assetName,object asset,float duration,object userData)=>
        //         {
        //             var ability = CombatEntity.GetComponent<SkillComponent>().AttachSkill(asset);
        //         }, null, null, null);
        //         GameEntry.Resource.LoadAsset(skillConfigObjectPath, m_LoadAssetCallbacks);
        //     }
        // }
        
        
        var ExecutionLinkPanelObj = GameObject.Find("ExecutionLinkPanel");
        if (ExecutionLinkPanelObj != null)
        {
            ExecutionLinkPanelObj.GetComponent<ExecutionLinkPanel>().HeroEntity = CombatEntity;
        }
    }
    private void OnPreSpell(Entity combatAction)
    {
        // var spellAction = combatAction as SpellAction;
        // if (spellAction.InputTarget != null)
        // {
        //     CombatEntity.ModelTrans.localRotation = Quaternion.LookRotation(spellAction.InputTarget.Position - CombatEntity.ModelTrans.position);
        // }
        // else
        // {
        //     CombatEntity.ModelTrans.localRotation = Quaternion.LookRotation(spellAction.InputPoint - CombatEntity.ModelTrans.position);
        // }
        // DisableMove();
        //
        // if (spellAction.SkillExecution != null)
        // {
        //     if (spellAction.SkillAbility.HasComponent<Skill1006Component>())
        //     {
        //         return;
        //     }
        //
        //     if (spellAction.SkillExecution.InputTarget != null)
        //         transform.GetChild(0).LookAt(spellAction.SkillExecution.InputTarget.Position);
        //     else if (spellAction.SkillExecution.InputPoint != null)
        //         transform.GetChild(0).LookAt(spellAction.SkillExecution.InputPoint);
        //     else
        //         transform.GetChild(0).localEulerAngles = new Vector3(0, spellAction.SkillExecution.InputRadian, 0);
        //
        //     CombatEntity.Position = transform.position;
        //     CombatEntity.Rotation = transform.GetChild(0).localRotation;
        // }
    }

    private void OnPostSpell(Entity combatAction)
    {
        var spellAction = combatAction as SpellAction;
        if (spellAction.SkillExecution != null)
        {
            //AnimationComponent.PlayFade(AnimationComponent.IdleAnimation);
        }
    }

    private void OnReceiveDamage(Entity combatAction)
    {
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

    private void OnReceiveCure(Entity combatAction)
    {
        // var cureAction = combatAction as CureAction;
        // HealthBarImage.fillAmount = CombatEntity.CurrentHealth.ToPercent();
        // var cureText = GameObject.Instantiate(CureText);
        // cureText.transform.SetParent(CanvasTrm);
        // cureText.transform.localPosition = Vector3.up * 120;
        // cureText.transform.localScale = Vector3.one;
        // cureText.transform.localEulerAngles = Vector3.zero;
        // cureText.text = $"+{cureAction.CureValue}";
        // cureText.GetComponent<DOTweenAnimation>().DORestart();
        // GameObject.Destroy(cureText.gameObject, 0.5f);
    }

    //收到状态改变
    private void OnReceiveStatus(Entity combatAction)
    {
        //var action = combatAction as AddStatusAction;
        //var addStatusEffect = action.AddStatusEffect;
        //var statusConfig = addStatusEffect.AddStatus;
        //if (name == "Monster")
        //{
        //    var obj = GameObject.Instantiate(StatusIconPrefab);
        //    obj.transform.SetParent(StatusSlotsTrm);
        //    obj.GetComponentInChildren<Text>().text = statusConfig.Name;
        //    obj.name = action.Status.Id.ToString();
        //}

        //if (statusConfig.ID == "Vertigo")
        //{
        //    AnimationComponent.AnimancerComponent.Play(AnimationComponent.StunAnimation);
        //    if (vertigoParticle == null)
        //    {
        //        vertigoParticle = GameObject.Instantiate(statusConfig.ParticleEffect);
        //        vertigoParticle.transform.parent = transform;
        //        vertigoParticle.transform.localPosition = new Vector3(0, 2, 0);
        //    }
        //}
        //if (statusConfig.ID == "Weak")
        //{
        //    if (weakParticle == null)
        //    {
        //        weakParticle = GameObject.Instantiate(statusConfig.ParticleEffect);
        //        weakParticle.transform.parent = transform;
        //        weakParticle.transform.localPosition = new Vector3(0, 0, 0);
        //    }
        //}
    }

    //解除一个状态
    private void OnRemoveStatus(RemoveStatusEvent eventData)
    {
        //if (name == "Monster")
        //{
        //    var trm = StatusSlotsTrm.Find(eventData.StatusId.ToString());
        //    if (trm != null)
        //    {
        //        GameObject.Destroy(trm.gameObject);
        //    }
        //}

        //var statusConfig = eventData.Status.StatusConfigObject;
        //if (statusConfig.ID == "Vertigo")
        //{
        //    AnimationComponent.AnimancerComponent.Play(AnimationComponent.IdleAnimation);
        //    if (vertigoParticle != null)
        //    {
        //        GameObject.Destroy(vertigoParticle);
        //    }
        //}
        //if (statusConfig.ID == "Weak")
        //{
        //    if (weakParticle != null)
        //    {
        //        GameObject.Destroy(weakParticle);
        //    }
        //}
    }

    private void OnPlayAnimation(AnimationClip animationClip)
    {
        AnimationComponent.PlayFade(animationClip);
    }
}