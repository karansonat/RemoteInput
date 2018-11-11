using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using MalbersAnimations.Events;

namespace MalbersAnimations
{
    public class MalbersInput : MonoBehaviour
    {
        #region Variables
        // private iMalbersInputs mCharacter;
        private IMCharacter mCharacter;

        private IInputSystem Input_System;
        private Vector3 m_CamForward;
        private Vector3 m_Move;
        private Transform m_Cam;

        public List<InputRow> inputs = new List<InputRow>();                                        //Used to convert them to dictionary
        protected Dictionary<string, InputRow> DInputs = new Dictionary<string, InputRow>();        //Shame it cannot be Serialided :(

        public InputAxis Horizontal = new InputAxis("Horizontal", true, true);
        public InputAxis Vertical = new InputAxis("Vertical", true, true);
        //public InputAxis UpDown = new InputAxis("UpDown", true, AxisType.Raw);
        [SerializeField]
        public bool cameraBaseInput;
        [SerializeField]
        private bool alwaysForward;

        private float h;        //Horizontal Right & Left   Axis X
        private float v;        //Vertical   Forward & Back Axis Z
        //private float u;      //Vertical   Forward & Back Axis Z

        public string PlayerID = "Player0"; //This is use for Rewired Asset
        #endregion

        public bool CameraBaseInput
        {
            get { return cameraBaseInput; }
            set { cameraBaseInput = value; }
        }

        public bool AlwaysForward
        {
            get { return alwaysForward; }
            set { alwaysForward = value; }
        }

        void Awake()
        {

            Input_System = DefaultInput.GetInputSystem(PlayerID);                   //Get Which Input System is being used
            Horizontal.InputSystem = Vertical.InputSystem = Input_System;
            //UpDown.InputSystem = Input_System;

            foreach (var i in inputs) i.InputSystem = Input_System;                 //Update to all the Inputs the Input System
            List_to_Dictionary();

            InitializeCharacter();
        }

        void InitializeCharacter()
        {
            mCharacter = GetComponent<IMCharacter>();

            if (mCharacter != null)
            {
                var keys = new Dictionary<string, BoolEvent>();

                foreach (var dinput in DInputs)
                {
                    keys.Add(dinput.Key, dinput.Value.OnInputChanged); //Use OnINPUT CHANGE INSTEAD OF ON INPUT PRESSED ... IS CALLED LESS TImes
                }
                mCharacter.InitializeInputs(keys);
            }
        }

        void OnDisable()
        {
            if (mCharacter != null) mCharacter.Move(Vector3.zero);       //When the Input is Disable make sure the character/animal is not moving.
        }

        void Start()
        {
            if (Camera.main != null)                                                //Get the transform of the main camera
                m_Cam = Camera.main.transform;
            else
                m_Cam = GameObject.FindObjectOfType<Camera>().transform;
        }

        void Update()
        {
            SetInput();
        }

        /// <summary>
        /// Send all the Inputs to the Animal
        /// </summary>
        protected virtual void SetInput()
        {
            h = Horizontal.GetAxis;
            v = alwaysForward ? 1 : Vertical.GetAxis;
            //u = UpDown.GetAxis;
            CharacterMove();

            foreach (var item in inputs) { var InputValue = item.GetInput;}             //This will set the Current Input value to the inputs and Invoke the Values
            //CharacterSync();
        }

        private void CharacterMove()
        {
            if (mCharacter != null)
            {
                if (cameraBaseInput)
                    mCharacter.Move(CameraInputBased());
                else
                    mCharacter.Move(new Vector3(h, 0, v), false);
            }
        }

        /// <summary>
        /// Calculate the Input Axis relative to the camera
        /// </summary>
        Vector3 CameraInputBased()
        {
            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, Vector3.one).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
            return m_Move;
        }

        /// <summary>
        /// Enable/Disable the Input
        /// </summary>
        public virtual void EnableInput(string inputName, bool value)
        {
            InputRow i;

            i = inputs.Find(item => item.name == inputName);

            if (i!=null)
                i.active = value;
          

            //if (DInputs.TryGetValue(name, out i))
            //    i.active = value;
        }

        /// <summary>
        /// Check if the input is active
        /// </summary>
        public virtual bool IsActive(string name)
        {
            InputRow input;

            if (DInputs.TryGetValue(name, out input))
                return input.active;

            return false;
        }

        public virtual InputRow FindInput(string name)
        {
            InputRow input = inputs.Find(item => item.name.ToUpper() == name.ToUpper());

            if (input != null) return input;

            return null;
        }

        private void Reset()
        {
            inputs = new List<InputRow>()
            {
                {new InputRow("Jump", "Jump", KeyCode.Space, InputButton.Press, InputType.Input)},
                {new InputRow("Shift", "Fire3", KeyCode.LeftShift, InputButton.Press, InputType.Input)},
                {new InputRow("Attack1", "Fire1", KeyCode.Mouse0, InputButton.Press, InputType.Input)},
                {new InputRow("Attack2", "Fire2", KeyCode.Mouse1, InputButton.Press, InputType.Input)},
                {new InputRow(false,"SpeedDown", "SpeedDown", KeyCode.Alpha1, InputButton.Down, InputType.Key)},
                {new InputRow(false,"SpeedUp", "SpeedUp", KeyCode.Alpha2, InputButton.Down, InputType.Key)},
                {new InputRow("Speed1", "Speed1", KeyCode.Alpha1, InputButton.Down, InputType.Key)},
                {new InputRow("Speed2", "Speed2", KeyCode.Alpha2, InputButton.Down, InputType.Key)},
                {new InputRow("Speed3", "Speed3", KeyCode.Alpha3, InputButton.Down, InputType.Key)},
                {new InputRow("Action", "Action", KeyCode.E, InputButton.Down, InputType.Key)},
                {new InputRow("Fly", "Fly", KeyCode.Q, InputButton.Down, InputType.Key)},
                {new InputRow("Dodge", "Dodge", KeyCode.R, InputButton.Down, InputType.Key)},
                {new InputRow("Down", "Down", KeyCode.C, InputButton.Press, InputType.Key)},
                {new InputRow("Up", "Jump", KeyCode.Space, InputButton.Press, InputType.Input) },
                {new InputRow("Stun", "Stun", KeyCode.H, InputButton.Press, InputType.Key)},
                {new InputRow("Damaged", "Damaged", KeyCode.J, InputButton.Down, InputType.Key)},
                {new InputRow("Death", "Death", KeyCode.K, InputButton.Down, InputType.Key)},
            };
        }

        /// <summary>
        /// Convert the List of Inputs into a Dictionary
        /// </summary>
        void List_to_Dictionary()
        {
            DInputs = new Dictionary<string, InputRow>();
            foreach (var item in inputs)
                DInputs.Add(item.name, item);
        }


        //#region Inputssss
        //protected InputRow Attack1;
        //protected InputRow Attack2;
        //protected InputRow Action;
        //protected InputRow Jump;
        //protected InputRow Shift;
        //protected InputRow Fly;
        //protected InputRow Down;
        //protected InputRow Up;
        //protected InputRow Dodge;
        //protected InputRow Death;
        //protected InputRow Stun;
        //protected InputRow Damaged;
        //protected InputRow Speed1;
        //protected InputRow Speed2;
        //protected InputRow Speed3;
        //protected InputRow SpeedDown;
        //protected InputRow SpeedUp;
        //#endregion

        //private void CharacterConnect()
        //{
        //    if (DInputs.TryGetValue("Attack1", out Attack1)) Attack1.OnInputChanged.AddListener(value => character.Attack1 = value);
        //    if (DInputs.TryGetValue("Attack2", out Attack2)) Attack2.OnInputChanged.AddListener(value => character.Attack2 = value);
        //    if (DInputs.TryGetValue("Action", out Action)) Action.OnInputChanged.AddListener(value => character.Action = value);

        //    if (DInputs.TryGetValue("Jump", out Jump)) Jump.OnInputChanged.AddListener(value => character.Jump = value);
        //    if (DInputs.TryGetValue("Shift", out Shift)) Shift.OnInputChanged.AddListener(value => character.Shift = value);
        //    if (DInputs.TryGetValue("Fly", out Fly)) Fly.OnInputChanged.AddListener(value => character.Fly = value);

        //    if (DInputs.TryGetValue("Down", out Down)) Down.OnInputChanged.AddListener(value => character.Down = value);
        //    if (DInputs.TryGetValue("Up", out Up)) Up.OnInputChanged.AddListener(value => character.Up = value);

        //    if (DInputs.TryGetValue("Dodge", out Dodge)) Dodge.OnInputChanged.AddListener(value => character.Dodge = value);
        //    if (DInputs.TryGetValue("Death", out Death)) Death.OnInputChanged.AddListener(value => character.Death = value);
        //    if (DInputs.TryGetValue("Stun", out Stun)) Stun.OnInputChanged.AddListener(value => character.Stun = value);
        //    if (DInputs.TryGetValue("Damaged", out Damaged)) Damaged.OnInputChanged.AddListener(value => character.Damaged = value);

        //    if (DInputs.TryGetValue("Speed1", out Speed1)) Speed1.OnInputChanged.AddListener(value => character.Speed1 = value);
        //    if (DInputs.TryGetValue("Speed2", out Speed2)) Speed2.OnInputChanged.AddListener(value => character.Speed2 = value);
        //    if (DInputs.TryGetValue("Speed3", out Speed3)) Speed3.OnInputChanged.AddListener(value => character.Speed3 = value);

        //    if (DInputs.TryGetValue("SpeedUp", out SpeedUp)) SpeedUp.OnInputChanged.AddListener(value => character.SpeedUp = value);
        //    if (DInputs.TryGetValue("SpeedDown", out SpeedDown)) SpeedDown.OnInputChanged.AddListener(value => character.SpeedDown = value);
        //}


        //private void CharacterSync()
        //{
        //    if (character != null)
        //    {
        //        //-----------MOVE THE CHARACTER 
        //        if (cameraBaseInput)
        //            character.Move(CameraInputBased());
        //        else
        //            character.Move(new Vector3(h, 0, v), false);
        //        //----------------------------------------------


        //        if (Attack1 != null && Attack1.active) character.Attack1 = Attack1.InputValue;        //Get the Attack1 button
        //        if (Attack2 != null && Attack2.active) character.Attack2 = Attack2.InputValue;        //Get the Attack2 button

        //        if (Action != null && Action.active) character.Action = Action.InputValue;            //Get the Action/Emotion button

        //        if (Jump != null && Jump.active) character.Jump = Jump.InputValue;                    //Get the Jump button
        //        if (Shift != null && Shift.active) character.Shift = Shift.InputValue;                //Get the Shift button

        //        if (Fly != null && Fly.active) character.Fly = Fly.InputValue;                        //Get the Fly button
        //        if (Down != null && Down.active) character.Down = Down.InputValue;                    //Get the Down button
        //        if (Up != null && Up.active) character.Up = Up.InputValue;                            //Get the Down button
        //        if (Dodge != null && Dodge.active) character.Dodge = Dodge.InputValue;                //Get the Dodge button

        //        if (Stun != null && Stun.active) character.Stun = Stun.InputValue;                    //Get the Stun button
        //        if (Death != null && Death.active) character.Death = Death.InputValue;                //Get the Death button
        //        if (Damaged != null && Damaged.active) character.Damaged = Damaged.InputValue;        //Get the Damaged button

        //        if (Speed1 != null && Speed1.active) character.Speed1 = Speed1.InputValue;            //Get the Speed1 button
        //        if (Speed2 != null && Speed2.active) character.Speed2 = Speed2.InputValue;            //Get the Speed2 button
        //        if (Speed3 != null && Speed3.active) character.Speed3 = Speed3.InputValue;            //Get the Speed3 button

        //        if (SpeedUp != null && SpeedUp.active) character.SpeedUp = SpeedUp.InputValue;        //Get the Speed3 button
        //        if (SpeedDown != null && SpeedDown.active) character.SpeedDown = SpeedDown.InputValue;//Get the Speed3 button
        //    }
        //}


        //private void FindAllInputs()
        //{
        //    Attack1 = FindInput("Attack1");
        //    Attack2 = FindInput("Attack2");
        //    Action = FindInput("Action");
        //    Jump = FindInput("Jump");
        //    Shift = FindInput("Shift");
        //    Fly = FindInput("Fly");
        //    Down = FindInput("Down");
        //    Up = FindInput("Up");
        //    Dodge = FindInput("Dodge");
        //    Death = FindInput("Death");
        //    Stun = FindInput("Stun");
        //    Damaged = FindInput("Damaged");
        //    Speed1 = FindInput("Speed1");
        //    Speed2 = FindInput("Speed2");
        //    Speed3 = FindInput("Speed3");

        //    SpeedUp = FindInput("SpeedUp");
        //    SpeedDown = FindInput("SpeedDown");

        //}
    }
    ///──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
    #region InputRow and Input Axis
    /// <summary>
    /// Input Class to change directly between Keys and Unity Inputs
    /// </summary>
    [System.Serializable]
    public class InputRow
    {
        public bool active = true;
        public string name = "InputName";
        public InputType type = InputType.Input;
        public string input = "Value";
        public KeyCode key = KeyCode.A;
        public InputButton GetPressed = InputButton.Press;
        /// <summary>
        /// Current Input Value
        /// </summary>
        public bool InputValue = false;
        public UnityEvent OnInputDown = new UnityEvent();
        public UnityEvent OnInputUp = new UnityEvent();
        public UnityEvent OnInputPressed = new UnityEvent();
        public BoolEvent OnInputChanged = new BoolEvent();

        protected IInputSystem inputSystem = new DefaultInput();


        /// <summary>
        /// Return True or False to the Selected type of Input of choice
        /// </summary>
        public virtual bool GetInput
        {
            get
            {
                if (!active) return false;
                if (inputSystem == null) return false;

                var oldValue = InputValue;

                switch (type)
                {
                    case InputType.Input:
                        switch (GetPressed)
                        {
                            case InputButton.Press:
                                InputValue = InputSystem.GetButton(input);
                                if (oldValue != InputValue)
                                {
                                    if (InputValue) OnInputDown.Invoke();
                                    else OnInputUp.Invoke();

                                    OnInputChanged.Invoke(InputValue);
                                }
                                if (InputValue) OnInputPressed.Invoke();

                                return InputValue;

                            case InputButton.Down:
                                InputValue = InputSystem.GetButtonDown(input);
                                if (oldValue != InputValue)
                                {
                                    if (InputValue) OnInputDown.Invoke();
                                    OnInputChanged.Invoke(InputValue);
                                }

                                return InputValue;
                            case InputButton.Up:
                                InputValue = InputSystem.GetButtonUp(input);
                                if (oldValue != InputValue)
                                {
                                    if (InputValue) OnInputUp.Invoke();
                                    OnInputChanged.Invoke(InputValue);
                                }
                                return InputValue;
                        }
                        break;

                    case InputType.Key:
                        switch (GetPressed)
                        {
                            case InputButton.Press:
                                InputValue = Input.GetKey(key);

                                if (oldValue != InputValue)
                                {
                                    if (InputValue) OnInputDown.Invoke();
                                    else OnInputUp.Invoke();

                                    OnInputChanged.Invoke(InputValue);
                                }
                                if (InputValue) OnInputPressed.Invoke();

                                return InputValue;

                            case InputButton.Down:
                                InputValue = Input.GetKeyDown(key);

                                if (oldValue != InputValue)
                                {
                                    if (InputValue) OnInputDown.Invoke();
                                    OnInputChanged.Invoke(InputValue);
                                }

                                return InputValue;

                            case InputButton.Up:
                                InputValue = Input.GetKeyUp(key);

                                if (oldValue != InputValue)
                                {
                                    if (InputValue) OnInputUp.Invoke();
                                    OnInputChanged.Invoke(InputValue);
                                }
                                return InputValue;
                        }
                        break;
                    default:
                        break;
                }
                return false;
            }
        }

        public IInputSystem InputSystem
        {
            get { return inputSystem; }
            set { inputSystem = value; }
        }

        #region Constructors

        public InputRow(KeyCode k)
        {
            active = true;
            type = InputType.Key;
            key = k;
            GetPressed = InputButton.Down;
            inputSystem = new DefaultInput();
        }

        public InputRow(string input, KeyCode key)
        {
            active = true;
            type = InputType.Key;
            this.key = key;
            this.input = input;
            GetPressed = InputButton.Down;
            inputSystem = new DefaultInput();
        }

        public InputRow(string unityInput, KeyCode k, InputButton pressed)
        {
            active = true;
            type = InputType.Key;
            key = k;
            input = unityInput;
            GetPressed = InputButton.Down;
            inputSystem = new DefaultInput();
        }

        public InputRow(string name, string unityInput, KeyCode k, InputButton pressed, InputType itype)
        {
            this.name = name;
            active = true;
            type = itype;
            key = k;
            input = unityInput;
            GetPressed = pressed;
            inputSystem = new DefaultInput();
        }

        public InputRow(bool active , string name, string unityInput, KeyCode k, InputButton pressed, InputType itype)
        {
            this.name = name;
            this.active = active;
            type = itype;
            key = k;
            input = unityInput;
            GetPressed = pressed;
            inputSystem = new DefaultInput();
        }

        public InputRow()
        {
            active = true;
            name = "InputName";
            type = InputType.Input;
            input = "Value";
            key = KeyCode.A;
            GetPressed = InputButton.Press;
            inputSystem = new DefaultInput();
        }

        #endregion
    }
    ///──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
    [System.Serializable]
    public class InputAxis
    {
        public bool active = true;
        public string name = "NewAxis";
        public bool raw = true;
        public string input = "Value";
        IInputSystem inputSystem = new DefaultInput();
        public FloatEvent OnAxisValueChanged = new FloatEvent();
        float currentAxisValue = 0;


        /// <summary>
        /// Returns the Axis Value
        /// </summary>
        public float GetAxis
        {
            get
            {
                if (inputSystem == null || !active) return 0f;

                currentAxisValue = raw ? inputSystem.GetAxisRaw(input) : inputSystem.GetAxis(input);

             //   OnAxisValueChanged.Invoke(currentAxisValue);
                return currentAxisValue;
            }
        }

        /// <summary>
        /// Set/Get which Input System this Axis is using by Default is set to use the Unity Input System
        /// </summary>
        public IInputSystem InputSystem
        {
            get { return inputSystem; }
            set { inputSystem = value; }
        }

        public InputAxis()
        {
            active = true;
            raw = true;
            input = "Value";
            name = "NewAxis";
            inputSystem = new DefaultInput();
        }

        public InputAxis(string value)
        {
            active = true;
            raw = false;
            input = value;
            name = "NewAxis";
            inputSystem = new DefaultInput();
        }

        public InputAxis(string InputValue, bool active, bool isRaw)
        {
            this.active = active;
            this.raw = isRaw;
            input = InputValue;
            name = "NewAxis";
            inputSystem = new DefaultInput();
        }

        public InputAxis(string name, string InputValue, bool active, bool raw)
        {
            this.active = active;
            this.raw = raw;
            input = InputValue;
            this.name = name;
            inputSystem = new DefaultInput();
        }

    }
    #endregion
}