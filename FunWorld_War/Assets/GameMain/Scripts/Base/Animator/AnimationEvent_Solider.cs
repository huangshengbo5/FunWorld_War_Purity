using GameFramework.ObjectPool;
using UnityEngine;

namespace Script.Game.Base.Animator
{
    public class AnimationEvent_Solider : MonoBehaviour
    {
        public Solider solider;
        public void OnAnimationAttackHit()
        {
            solider.OnAnimationAttackHit();
        }
    }
}