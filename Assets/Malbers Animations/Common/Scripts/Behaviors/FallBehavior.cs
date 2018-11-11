using UnityEngine;
using System.Collections;

namespace MalbersAnimations
{
    public class FallBehavior : StateMachineBehaviour
    {
        RaycastHit FallRay;
        
        [Tooltip("The Lower Fall animation will set to 1 if this distance the current distance to the ground")]
        public float LowerDistance;
        Animal animal;
        Rigidbody rb;
        float MaxHeight; //this is to store the max Y heigth before falling

        float FallBlend;
        bool check_Water;

        int PivotsRayInterval;
        int FallRayInterval;
        int WaterRayInterval;
        int GroundLayer;

        Vector3 IncomingSpeed;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animal = animator.GetComponent<Animal>();
            rb = animator.GetComponent<Rigidbody>();

            GroundLayer = animal.GroundLayer;

            IncomingSpeed = rb.velocity;
            IncomingSpeed.y = 0;

            animal.SetIntID(1);
            animal.IsInAir = true;                                          //the  Animal is on the air (This also changes the RigidBody Constraints)
            animator.SetFloat(Hash.IDFloat, 1);                             //Is use to blend between the low and high fall animations 

            MaxHeight = float.MinValue; //Resets MaxHeight

            animator.applyRootMotion = false;

            rb.drag = 0;
            rb.useGravity = true;
            FallBlend = 1;


            check_Water = false;                                            //Reset the found water parameter..
            animal.Waterlevel = Animal.LowWaterLevel;                       //Reset the Water to the lowest level while is on the Fall state
            waterlevel = Animal.LowWaterLevel;

            animal.RaycastWater();                                          //Check for WaterCasting one more time
           
            PivotsRayInterval = animal.PivotsRayInterval;
            FallRayInterval = animal.FallRayInterval;
            WaterRayInterval = animal.WaterRayInterval;

            animal.PivotsRayInterval = animal.FallRayInterval = animal.WaterRayInterval = 1;    //Set the EveryFrame to 1 so have more precision
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //if (!animator.IsInTransition(layerIndex))
            //{
            //    rb.useGravity = true;
            //    animator.applyRootMotion = false;
            //    rb.constraints = RigidbodyConstraints.FreezeRotation;
            //}

            if (animal.debug)  Debug.DrawRay(animal.Main_Pivot_Point, -animal.transform.up * 50, Color.magenta);


            if (Physics.Raycast(animal.Main_Pivot_Point, -animal.transform.up, out FallRay, 50, GroundLayer))
            {
                if (MaxHeight < FallRay.distance)
                {
                    MaxHeight = FallRay.distance; //get the Highest Distance the first time you touch the ground
                }

                FallBlend = Mathf.Lerp(FallBlend, (FallRay.distance - LowerDistance) / (MaxHeight - LowerDistance), Time.deltaTime * 20); //Small blend in case there's a new ground found

                animator.SetFloat(Hash.IDFloat, FallBlend); //Blend between High and Low Fall

            }
            CheckforWater();
        }

        float waterlevel;

        private void CheckforWater()
        {
            if (waterlevel != animal.Waterlevel && animal.Waterlevel != Animal.LowWaterLevel)   //Store the Water 
            {
                waterlevel = animal.Waterlevel;
            }

            if (!check_Water && waterlevel > animal.Main_Pivot_Point.y)      //Means that we found water and with the fall it might get skipped the water
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);             //Reset the rigidbody velocity
                check_Water = true;                                                     //This will avoid to do it multiple times
                animal.Swim = true;
                animal.Waterlevel = waterlevel;
            }
        }

        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (animal.AirControl) AirControl();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //Restore the Intervals for the raycasting
            animal.PivotsRayInterval = PivotsRayInterval;
            animal.FallRayInterval = FallRayInterval;
            animal.WaterRayInterval =WaterRayInterval;

            animal.AirControlDir = Vector3.zero;        //Remove the AirControlDir speed
        }

        //If the jump can be controlled on air
        void AirControl()
        {
            float deltaTime = Time.deltaTime;
            var VerticalSpeed = rb.velocity.y;
            var PlanarRawDirection = animal.RawDirection;
            PlanarRawDirection.y = 0;
            
            animal.AirControlDir = Vector3.Lerp(animal.AirControlDir, PlanarRawDirection, deltaTime * animal.airSmoothness);

            Debug.DrawRay(animal.transform.position, animal.AirControlDir, Color.yellow);

            Vector3 RB_Velocity = animal.AirControlDir * animal.airMaxSpeed;

            if (!animal.DirectionalMovement)
            {
                RB_Velocity = animal.transform.TransformDirection(RB_Velocity);
            }

            RB_Velocity.y = VerticalSpeed;

            //RB_Velocity += IncomingSpeed;
            //IncomingSpeed = Vector3.Lerp(IncomingSpeed, Vector3.zero , deltaTime * 5);

            rb.velocity = RB_Velocity;
        }
    }
}