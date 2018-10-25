using System;
using UnityEngine;

namespace RemoteInput.Core
{
    [Serializable]
    public class InputData
    {
        #region Fields

        [SerializeField] public Vector3 EulerAngles { get; set; }
        [SerializeField] public Vector3 Acceleration { get; set; }

        #endregion //Fields
    }
}
