using MalbersAnimations.Utilities;
using UnityEngine;


namespace MalbersAnimations
{
    /// <summary>
    /// Controls the Logic for RootMotion Jumps
    /// </summary>
    public class JumpBehaviour : StateMachineBehaviour
    {
        [Header("Checking Fall")]
        [Tooltip("Ray Length to check if the ground is at the same level all the time")]
        public float fallRay = 1.7f;

        [Tooltip("Terrain difference to be sure the animal will fall ")]
        public float threshold = 0.3f;

        [Tooltip("Animation normalized time to change to fall animation if the ray checks if the animal is falling ")]
        [Range(0,1)]
        public float willFall = 0.7f;

        [Header("Jump Up Cliff")]
        [Range(0, 1)]
        public float startEdge = 0.5f;
        [Range(0, 1)]
        public float finishEdge = 0.6f;
        public float CliffRay = 0.6f;

        [Space]
        [Header("Add more Height and Distance to the Jump")]
        public float JumpMultiplier = 1;
        public float ForwardMultiplier = 1;

        Animal animal;
        Rigidbody rb;


        bool Can_Add_ExtraJump;
        Vector3 ExtraJump;
       // Vector3 AirMovement;
       
        bool JumpPressed;

        float jumpPoint;
        float Rb_Y_Speed = 0;
        RaycastHit JumpRay;
       
        //float AirSmooth;

        float JumpSmoothPressed = 1;

        bool JumpEnd;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animal = animator.GetComponent<Animal>();
            rb = animator.GetComponent<Rigidbody>();
            animator.applyRootMotion = true;

            rb.constraints = RigidbodyConstraints.FreezeRotation;

            jumpPoint = animator.transform.position.y;          //Store the Heigh of the jump
            animal.InAir(true);
            animal.SetIntID(0);

            animal.OnJump.Invoke();     //Invoke that the Animal is Jumping
            Rb_Y_Speed = 0;             //For Flying


            var PlanarRawDirection = animal.RawDirection;
            PlanarRawDirection.y = 0;
            animal.AirControlDir = PlanarRawDirection;
           

           //----------------------------------------------------------------------------------------
            #region Jump Multiplier Start

           Can_Add_ExtraJump = (JumpMultiplier > 0 && animal.JumpHeightMultiplier > 0) || (ForwardMultiplier > 0 && animal.AirForwardMultiplier > 0);
            ExtraJump = ((Vector3.up * JumpMultiplier * animal.JumpHeightMultiplier) + (animator.transform.forward * ForwardMultiplier * animal.AirForwardMultiplier));

            JumpSmoothPressed = 1;
            JumpPressed = true;

            if (animal.JumpPress)
            {
                Can_Add_ExtraJump = JumpPressed = animal.Jump;  //if you release the Jump Input you cannot add more extra jump
            }
            #endregion
            JumpEnd = false;
            animator.SetFloat(Hash.IDFloat, 1);
        }


        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            bool isInTransition = animator.IsInTransition(layerIndex);
            bool isInLastTransition = isInTransition && stateInfo.normalizedTime > 0.5f;

            if (JumpPressed) JumpPressed = animal.Jump;

            //Since the speed is constantly changed while is jumping (with rootMotion) we need to add speed constantly WITH DELTAPOSITION trough out the whole jump
            if (!isInTransition && Can_Add_ExtraJump && !JumpEnd)
            {
                if (animal.JumpPress)
                {
                    var range = JumpPressed ? 1 : 0;
                    JumpSmoothPressed = Mathf.Lerp(JumpSmoothPressed, range, Time.deltaTime * 5);
                }

                animal.DeltaPosition += (ExtraJump * Time.deltaTime * JumpSmoothPressed);
            }

            if (animal.FrameCounter % animal.FallRayInterval == 0)        //Skip to reduce aditional raycasting
            {
                Can_Fall(stateInfo.normalizedTime);
                Can_Jump_on_Cliff(stateInfo.normalizedTime);
            }


            #region if is transitioning to flying

            //If the next animation is FLY smoothly remove the Y rigidbody speed
            if (rb && isInLastTransition && animator.GetNextAnimatorStateInfo(layerIndex).tagHash == AnimTag.Fly)
            {
                float transitionTime = animator.GetAnimatorTransitionInfo(layerIndex).normalizedTime;
                Vector3 cleanY = rb.velocity;

                if (Rb_Y_Speed < cleanY.y) Rb_Y_Speed = cleanY.y; //Get the max Y SPEED

                cleanY.y = Mathf.Lerp(Rb_Y_Speed, 0, transitionTime);

                rb.velocity = cleanY;
            }
            #endregion
        }

        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (animal.AirControl) AirControl();
        }

        //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animal.SetIntID(0);

            var currentState = animator.GetCurrentAnimatorStateInfo(layerIndex);

            if (currentState.tagHash == AnimTag.Fly)                                 //if the next animation is fly then clean the rigidbody velocity on the Y axis
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
            else if (currentState.tagHash != AnimTag.Fall)                          //if the next state is NOT Fall or Fly set the Ground_Constraints
            {
                animal.IsInAir = false;
            }

            JumpEnd = true;
        }

        /// <summary>
        ///  Check if the animal can change to fall state if there's no future ground to land on
        /// </summary>
        /// <param name="normalizedTime"></param>
        void Can_Fall(float normalizedTime)
        {
            Debug.DrawRay(animal.Pivot_fall, -animal.transform.up * animal.Pivot_Multiplier * fallRay, Color.red);

           
            if (Physics.Raycast(animal.Pivot_fall, -animal.transform.up, out JumpRay, animal.Pivot_Multiplier * fallRay, animal.GroundLayer))
            {
                if ((jumpPoint - JumpRay.point.y) <= (threshold * animal.ScaleFactor)
                    && (Vector3.Angle(JumpRay.normal, Vector3.up) < animal.maxAngleSlope))      //If if finding a lower jump point;
                {
                    animal.SetIntID(0);                                                         //Keep the INTID in 0
                    MalbersTools.DebugTriangle(JumpRay.point, 0.1f, Color.red);
                }
                else
                {
                    if (normalizedTime > willFall) animal.SetIntID(111);                        //Set INTID to 111 to activate the FALL transition
                    MalbersTools.DebugTriangle(JumpRay.point, 0.1f, Color.yellow);
                }
            }
            else
            {
                if (normalizedTime > willFall) animal.SetIntID(111); //Set INTID to 111 to activate the FALL transition

                MalbersTools.DebugPlane(animal.Pivot_fall - (animal.transform.up * animal.Pivot_Multiplier * fallRay), 0.1f, Color.red);
            }
        }

        /// <summary>
        /// ─Get jumping on a cliff 
        /// </summary>
        /// <param name="normalizedTime"></param>
        void Can_Jump_on_Cliff(float normalizedTime)
        {
            if (normalizedTime >= startEdge && normalizedTime <= finishEdge)
            {
                if (Physics.Raycast(animal.Main_Pivot_Point, -animal.transform.up, out JumpRay, CliffRay * animal.ScaleFactor, animal.GroundLayer))
                {
                    if (Vector3.Angle(JumpRay.normal, Vector3.up) < animal.maxAngleSlope)       //Jump to a jumpable cliff not an inclined one
                    {
                        if (animal.debug)
                        {
                            Debug.DrawLine(animal.Main_Pivot_Point, JumpRay.point, Color.black);
                            MalbersTools.DebugTriangle(JumpRay.point, 0.1f, Color.black);
                        }
                        animal.SetIntID(110);
                    }
                }
                else
                {
                    if (animal.debug)
                    {
                        Debug.DrawRay(animal.Main_Pivot_Point, -animal.transform.up * CliffRay * animal.ScaleFactor, Color.black);
                        MalbersTools.DebugPlane(animal.Main_Pivot_Point - (animal.transform.up * CliffRay * animal.ScaleFactor), 0.1f, Color.black);
                    }
                }
            }
        }

        //If the jump can be controlled on air
        void AirControl()
        {
            float deltaTime = Time.deltaTime;
            var VerticalSpeed = rb.velocity.y;
            var PlanarRawDirection = animal.RawDirection;
            PlanarRawDirection.y = 0;

            animal.AirControlDir = Vector3.Lerp(animal.AirControlDir, PlanarRawDirection * ForwardMultiplier, deltaTime * animal.airSmoothness);

            Debug.DrawRay(animal.transform.position, animal.AirControlDir, Color.yellow);

            Vector3 RB_Velocity = animal.AirControlDir * animal.airMaxSpeed;

            if (!animal.DirectionalMovement)
            {
                RB_Velocity = animal.transform.TransformDirection(RB_Velocity);
            }

            RB_Velocity.y = VerticalSpeed;

            //RB_Velocity += IncomingSpeed;
            //IncomingSpeed = Vector3.Lerp(IncomingSpeed, Vector3.zero , deltaTime * 10);

            rb.velocity = RB_Velocity;
        }
    }
}



