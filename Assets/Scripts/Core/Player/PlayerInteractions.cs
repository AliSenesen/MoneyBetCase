using System;
using System.Collections;
using System.Collections.Generic;
using Core.QuestionArea;
using Signals;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Controllers
{
    public class PlayerInteractions : MonoBehaviour
    {
        [SerializeField] private float moneyDropDelay;
        private float _moneyYOffset = 0f;
        [ShowInInspector] private List<Money> _moneyList = new();
        private BetBelt _betBelt;
        
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
                _moneyList.Add(money);
            }

            if (other.TryGetComponent(out BetBelt betBelt))
            {
                StartCoroutine(DropMoneyCoroutine(betBelt));
            }

           
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out BetBelt betBelt))
            {
                StopCoroutine(DropMoneyCoroutine(betBelt));
            }
        }

        private IEnumerator DropMoneyCoroutine(BetBelt belt)
        {
            while (true)
            {
                if (_moneyList.IsNullOrEmpty())
                {
                    break;
                }
                var tempMoney = _moneyList[_moneyList.Count-1];
                belt.SendMoneyToBank(tempMoney);
                _moneyList.Remove(tempMoney);
                yield return new WaitForSeconds(moneyDropDelay);
            }
        }

    }
}