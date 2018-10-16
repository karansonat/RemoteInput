using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace RemoteInput.Core
{
    public class InputData
    {
        #region Fields

        public Gyroscope _gyroscope { get; private set; }
        public Vector3 _acceleration { get; private set; }

        #endregion //Fields

        #region Constructor

        public InputData(Gyroscope gyro, Vector3 acceleration)
        {
            _gyroscope = gyro;
            _acceleration = acceleration;
        }

        #endregion //Constructor
    }
}
