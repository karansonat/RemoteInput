using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
    [CreateAssetMenu(menuName = "Malbers Animations/Effect Modifiers/FireBall")]
    public class FireBallEffectM : EffectModifier
    {
        public float velocity = 300;
        Rigidbody rb;
        LookAt hasLookAt;

        public override void AwakeEffect(Effect effect){}
        
        public override void StartEffect(Effect effect)
        {
            rb = effect.Instance.GetComponent<Rigidbody>();         //Get the riggidbody of the effect
            hasLookAt = effect.Owner.GetComponent<LookAt>();        //Check if the owner has lookAt

            effect.Instance.SendMessage("SetOwner", effect.Owner.gameObject, SendMessageOptions.DontRequireReceiver);
           
            if (hasLookAt && hasLookAt.active && hasLookAt.IsAiming)
            {
                rb.AddForce(hasLookAt.Direction.normalized * velocity);
            }
            else
            {
                Animator ownerAnimator = effect.Owner.GetComponent<Animator>();
                Vector3 velocityv = ownerAnimator.velocity.normalized;
                

                if (ownerAnimator.velocity.magnitude < 0.1)
                {
                    velocityv = effect.Owner.transform.forward;
                }
                rb.AddForce(velocityv * velocity);
            }
        }
    }
}