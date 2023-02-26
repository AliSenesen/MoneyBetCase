using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class AreaSignals : MonoSingleton<AreaSignals>
    {
        public UnityAction onGetMoneyBack = delegate {  };
        public UnityAction onTrueAnswer = delegate {  };
    }
}