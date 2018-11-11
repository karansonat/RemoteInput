using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations
{
    [CreateAssetMenu(menuName = "Malbers Animations/Animal Proxy")]
    public class AnimalProxy : ScriptableObject
    {
        protected Animal animal;

        [Tooltip("Since the Animal Proxy is a Scriptable Object... After Stoping the Editor an animal can get stored.. you can clean the reference on the next Editor Play enabling this option ")]
        public bool CleanAnimalOnEnable = false;


        private void OnEnable()
        {
            if (CleanAnimalOnEnable) animal = null;
        }

        public virtual Animal Animal
        {
            get { return animal; }
        }

        #region Properties

        /// <summary>
        /// Current Animal Speed in numbers, 1 = walk 2 = trot 3 = run 
        /// </summary>
        public virtual float GroundSpeed
        {
            set { animal.GroundSpeed = value; }
        }


        /// <summary>
        /// Speed from the Vertical input multiplied by the speeds inputs(Walk Trot Run) this is the value thats goes to the Animator, is not the actual Speed of the animals
        /// </summary>
        public virtual float Vertical
        {
            set { animal.Speed = value; }
            get { return animal.Speed; }
        }


        /// <summary>
        /// Controls the Loops for some animations that can be played for an ammount of cycles.
        /// </summary>
        public int Loops
        {
            set { animal.Loops = value; }
            get { return animal.Loops; }
        }

        public int IDInt
        {
            set { animal.IDInt = value; }
            get { return animal.IDInt; }
        }

        public float IDFloat
        {
            set { animal.IDFloat = value; }
            get { return animal.IDFloat; }
        }

        /// <summary>
        /// Amount of Idle acumulated if the animals is not moving, if Tired is greater than GotoSleep the animal will go to the sleep state.
        /// </summary>
        public int Tired
        {
            set { animal.Tired = value; }
            get { return animal.Tired; }
        }

        /// <summary>
        /// Change the Speed Up
        /// </summary>
        public bool SpeedUp
        {
            set { animal.SpeedUp = value; }
        }

        /// <summary>
        /// Changes the Speed Down
        /// </summary>
        public bool SpeedDown
        {
            set { animal.SpeedDown = value; }
        }

        /// <summary>
        /// Set the Animal Speed to Speed1
        /// </summary>
        public bool Speed1
        {
            set { animal.Speed1 = value; }
            get { return animal.Speed1; }
        }

        /// <summary>
        /// Set the Animal Speed to Speed2
        /// </summary>
        public bool Speed2
        {
            set { animal.Speed2 = value; }
            get { return animal.Speed2; }
        }

        /// <summary>
        /// Set the Animal Speed to Speed3
        /// </summary>
        public bool Speed3
        {
            set { animal.Speed3 = value; }
            get { return animal.Speed3; }
        }

        public bool Jump
        {
            set { animal.Jump = value; }
            get { return animal.Jump; }
        }

        /// <summary>
        /// is the Animal UnderWater
        /// </summary>
        public bool Underwater
        {
            set { animal.Underwater = value; }
            get { return animal.Underwater; }
        }

        /// <summary>
        /// Allows to use Sprint 
        /// </summary>
        public bool UseShift
        {
            set { animal.useShift = value; }
            get { return animal.useShift; }
        }

        public bool Shift
        {
            set { animal.Shift = value; }
            get { return animal.Shift; }
        }

        public bool Down
        {
            set { animal.Down = value; }
            get { return animal.Down; }
        }

        public bool Up
        {
            set { animal.Up = value; }
            get { return animal.Up; }
        }

        public bool Dodge
        {
            set { animal.Dodge = value; }
            get { return animal.Dodge; }
        }

        public bool Damaged
        {
            set { animal.Damaged = value; }
            get { return animal.Dodge; }
        }

        /// <summary>
        /// Toogle the Fly on and Off!!
        /// </summary>
        public bool Fly
        {
            set { animal.SetFly(value); }
            get { return animal.Fly; }
        }

        /// <summary>
        /// Toogle the Fly on and Off!!
        /// </summary>
        public void ToogleFly()
        {
            animal.Fly = true;
        }

        /// <summary>
        /// If set to true the animal will die
        /// </summary>
        public bool Death
        {
            set { animal.Death = value; }
            get { return animal.Death; }
        }

        /// <summary>
        /// Enables the Attack to the Current Active Attack
        /// </summary>
        public bool Attack1
        {
            set { animal.Attack1 = value; }
            get { return animal ? animal.Attack1 : false; }
        }

        public bool Attack2
        {
            set { animal.Attack2 = value; }
            get { return animal ? animal.Attack2 : false; }
        }

        public bool Stun
        {
            set { animal.Stun = value; }
            get { return animal.Stun; }
        }

        public bool Action
        {
            set { animal.Action = value; }
            get { return animal.Action; }
        }

        public int ActionID
        {
            set { animal.ActionID = value; }
            get { return animal.ActionID; }
        }

        /// <summary>
        /// Is the Animal on the Air, modifies the rigidbody constraints depending the IsInAir Value
        /// </summary>
        public bool IsInAir
        {
            set { animal.IsInAir = value; }
            get { return animal.IsInAir; }
        }

        public bool Stand
        {
            get { return animal.Stand; }
        }

        public Vector3 HitDirection
        {
            get { return animal.HitDirection; }
            set { animal.HitDirection = value; }
        }

        /// <summary>
        /// The Scale Factor of the Animal.. if the animal has being scaled this is the multiplier for the raycasting things
        /// </summary>
        public float ScaleFactor
        {
            get { return animal.ScaleFactor; }
        }

        public Pivots Pivot_Hip
        {
            get { return animal.Pivot_Hip; }
        }

        public Pivots Pivot_Chest
        {
            get { return animal.Pivot_Chest; }
        }



        /// <summary>
        /// Returns the Current Animation State Tag of animal, if is in transition it will return the NextState Tag
        /// </summary>
        public int AnimState
        {
            get { return animal.AnimState; }
        }


        public int LastAnimationTag
        {
            get { return animal.LastAnimationTag; }
        }

        /// <summary>
        /// Direction the animal to move
        /// </summary>
        public Vector3 MovementAxis
        {
            get { return animal.MovementAxis; }
            set { animal.MovementAxis = value; }
        }

        /// <summary>
        /// Returns Movement Axis Z value
        /// </summary>
        public float MovementForward
        {
            get { return animal.MovementForward; }
            set { animal.MovementForward = value; }
        }

        public float MovementRight
        {
            get { return animal.MovementRight; }
            set { animal.MovementRight = value; }
        }

        public float MovementUp
        {
            get { return animal.MovementUp; }
            set { animal.MovementUp = value; }
        }

        public Vector3 SurfaceNormal
        {
            get { return animal.SurfaceNormal; }
        }


        //Y value of the water Got it from the WaterRayCastHit
        public float Waterlevel
        {
            get { return animal.Waterlevel; }
            set { animal.Waterlevel = value; }
        }

        public bool Land
        {
            get { return animal.Land; }
            set { animal.Land = value; }
        }
        #endregion

        public virtual void SetAnimal(Animal newAnimal)
        { animal = newAnimal; }

        public virtual void getDamaged(DamageValues DV)
        { if (animal) animal.getDamaged(DV); }

        public virtual void Stop()
        { if (animal) animal.Stop(); }

        public virtual void getDamaged(Vector3 Mycenter, Vector3 Theircenter, float Amount = 0)
        {
            DamageValues DV = new DamageValues(Mycenter - Theircenter, Amount);
            getDamaged(DV);
        }

        public virtual void AttackTrigger(int triggerIndex)
        { if (animal) animal.AttackTrigger(triggerIndex); }

        public virtual void SetAttack()
        { if (animal) animal.SetAttack(); }

        public virtual void SetLoop(int cycles)
        { if (animal) animal.Loops = cycles; }

        public virtual void SetAttack(int attackID)
        { if (animal) animal.SetAttack(attackID); }

        public virtual void SetAttack(bool value)
        { Attack1 = value; }

        public virtual void SetSecondaryAttack()
        { if (animal) animal.SetSecondaryAttack(); }

        public virtual void RigidDrag(float amount)
        { if (animal) animal.RigidDrag(amount); }

        public void SetIntID(int value)
        { if (animal) animal.SetIntID(value); }

        public void SetFloatID(float value)
        {if (animal) animal.SetFloatID(value); }

        public virtual void StillConstraints(bool active)
        { if (animal) animal.StillConstraints(active); }

        public virtual void EnableColliders(bool active)
        { if (animal) animal.EnableColliders(active); }

        public virtual bool Gravity
        {
            set { if (animal) animal.Gravity = value; }
            get
            {
                if (animal) return animal.Gravity;
                return false;
            }
        }

        public virtual void InAir(bool active)
        { if (animal) animal.InAir(active); }

        public virtual void SetJump()
        { if (animal) animal.SetJump(); }

        public virtual void SetAction(int ID)
        { if (animal) animal.SetAction(ID); }

        public virtual void SetAction(string actionName)
        { if (animal) animal.SetAction(actionName); }

        public virtual void ResetAnimal()
        { if (animal) animal.ResetAnimal(); }

        public virtual void SetStun(float time)
        { if (animal) animal.SetStun(time); }


        public virtual void DisableAnimal()
        { if (animal) animal.DisableAnimal(); }

        public virtual void SetToGlide(float value)
        { if (animal) animal.SetToGlide(value); }
    }
}