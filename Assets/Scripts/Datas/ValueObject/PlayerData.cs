using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Datas.ValueObject
{
    [Serializable]
    public class PlayerData
    {
        public PlayerMovementData PlayerMovementData;
    }

    [Serializable]
    public class PlayerMovementData
    {
        public float ForwardSpeed = 5;
        public float SidewaysSpeed = 2;
    }
}