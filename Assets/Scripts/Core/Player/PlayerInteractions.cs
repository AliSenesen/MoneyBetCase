using System;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class PlayerInteractions : MonoBehaviour
    {
        private float _moneyYOffset = 0f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                PlayerSignals.Instance.onPlayerEnterFinishLine?.Invoke();
            }

            if (other.TryGetComponent(out Money money))
            {
                money.Collect(transform,_moneyYOffset);
                _moneyYOffset++;
            }
        }
        
    }
}