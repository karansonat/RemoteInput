using UnityEngine;

namespace MalbersAnimations
{
    public class FlyDodgeBehaviour : StateMachineBehaviour
    {
        public bool InPlace;
        Vector3 momentum;       //To Store the velocity that the animator had before entering this animation state
        Rigidbody rb;
        Animal animal;
        float time;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            rb = animator.GetComponent<Rigidbody>();
            animal = animator.GetComponent<Animal>();

            momentum = InPlace ? rb.velocity : animator.velocity;

        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            time = animator.updateMode == AnimatorUpdateMode.AnimatePhysics ? Time.fixedDeltaTime : Time.deltaTime;     //Get the Time Right

            animal.DeltaPosition += momentum * time;
        }
    }
}