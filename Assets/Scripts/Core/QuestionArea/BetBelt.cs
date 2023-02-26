using System.Collections.Generic;
using DG.Tweening;
using Signals;
using UnityEngine;


namespace Scripts.Core.QuestionArea
{
    public class BetBelt : MonoBehaviour
    {
        [SerializeField] private Transform moneyBank;
        [SerializeField] private bool isLeft;

        private int _moneyBankCounter = 0;
        private int _moneyBetCounter = 0;


        public int TakeRewardAmount()
        {
            return _moneyBetCounter;
        }

        public void SendMoneyToBank(Money money)
        {
            money.transform.parent = transform;
            money.transform.DOMove(
                new Vector3(transform.position.x, transform.position.y + 3f, money.transform.position.z), .2f, false);

            money.transform.DORotateQuaternion(isLeft ? Quaternion.Euler(0, 0, 90) : Quaternion.Euler(0, 0, -90), .2f)
                .OnComplete(() => LandOnBelt(money));
        }

        private void LandOnBelt(Money money)
        {
            money.transform.DOLocalMoveY(
                .6f, .2f, false);

            money.transform.DORotate(Vector3.zero, 1).OnComplete(() =>
                money.transform.DOMoveZ(moneyBank.transform.position.z, 25).SetSpeedBased(true).SetEase(Ease.Linear)
                    .OnComplete(() =>
                    {
                        _moneyBetCounter++;
                        if (_moneyBankCounter > 10)
                        {
                            return;
                        }

                        money.transform.DOMoveY(_moneyBankCounter, 0.35f, false);
                        _moneyBankCounter++;
                    }));
        }
    }
}