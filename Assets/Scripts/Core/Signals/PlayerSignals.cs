using System;
using System.Collections.Generic;
using Controllers;
using Extentions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public UnityAction<Transform> onGetEndGameCamToMoney;
        public UnityAction onPlayerEnterFinishLine = delegate {  };
        public Func<float> playerXPos;
        public Func<List<Money>> playerStack;
    }
}