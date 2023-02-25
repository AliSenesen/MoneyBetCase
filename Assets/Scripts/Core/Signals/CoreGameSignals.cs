using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        
        public UnityAction onPlay;
        public UnityAction onWin;
        public UnityAction onFail;
    }
}