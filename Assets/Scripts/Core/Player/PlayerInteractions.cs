using System;
using System.Collections;
using System.Collections.Generic;
using Core.QuestionArea;
using DG.Tweening;
using Scripts.Core.QuestionArea;
using Signals;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    public class PlayerInteractions : MonoBehaviour
    {
        [Header("stack manıpulation")] [SerializeField]
        private Transform moneyHolder;

        [SerializeField] private GameObject moneyPrefab;
        [SerializeField] private AnimationCurve angleCurve;
        [SerializeField] private AnimationCurve positionCurve;
        [SerializeField] private float maxAngle;
        [SerializeField] private float maxRoadXValue;
        [SerializeField] private Vector2 clampXPositions = new Vector2(-3.5f, 3.5f);
        [SerializeField] private float moneyXMultiplier;
        [Header("money")] [SerializeField] private float moneyDropDelay;
        private float _moneyYOffset = 0f;

        [ShowInInspector] private List<Money> _moneyList = new();
        private BetBelt _betBelt;

        private void OnEnable()
        {
            PlayerSignals.Instance.playerStack += GetMoneys;
        }


        private void OnDisable()
        {
            PlayerSignals.Instance.playerStack -= GetMoneys;
        }


        private void Update()
        {
            SetStackRotation();
        }

        private void SetStackRotation()
        {
            if (_moneyList.Count == 0)
            {
                return;
            }

            float playerXpos = PlayerSignals.Instance.playerXPos();


            for (int i = 0; i < _moneyList.Count; i++)
            {
                float playerPosRate = 0;

                playerPosRate = playerXpos / clampXPositions.x;

                float curveConstant = (float)i / _moneyList.Count;

                float desiredAngle = angleCurve.Evaluate(curveConstant) * maxAngle * playerPosRate;
                Quaternion currentAngle = _moneyList[i].transform.rotation;
                _moneyList[i].transform.rotation = Quaternion.Euler(currentAngle.x, currentAngle.y, desiredAngle);
                
                Vector3 currentPos = _moneyList[i].transform.localPosition;
               float desiredPosition = ((i*i)*moneyXMultiplier) * maxRoadXValue * -playerPosRate;
                _moneyList[i].transform.localPosition = new Vector3( desiredPosition, currentPos.y, currentPos.z);
            }
        }

        private List<Money> GetMoneys()
        {
            return _moneyList;
        }

        private void OnTriggerEnter(Collider other)
        {
             AddMoney(other.gameObject);

            if (other.TryGetComponent(out BetBelt betBelt))
            {
                 StartCoroutine(DropMoneyCoroutine(betBelt));
                
            }
            

            if (other.TryGetComponent(out SignBoardsMove signBoards))
            {
                signBoards.MoveSignBoards();
            }

            if (other.CompareTag("Finish"))
            {
                PlayerSignals.Instance.onPlayerEnterFinishLine?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out BetBelt betBelt))
            {
                StopCoroutine(DropMoneyCoroutine(betBelt));
            }

            if (other.TryGetComponent(out BetArea betArea))
            {
               var rewardAmount = betArea.GetBetReward();
               TakeReward(rewardAmount);
            }
        }

        private void TakeReward(int moneyAmount)
        {
            for (int i = 0; i < moneyAmount; i++)
            {
                GameObject rewardMoney =  Instantiate(moneyPrefab);
                AddMoney(rewardMoney);
                
            }
        }

        private void AddMoney(GameObject rewardMoney)
        {
            if (rewardMoney.TryGetComponent(out Money money))
            {
                money.Collect(moneyHolder, _moneyYOffset);
                _moneyYOffset += 0.5f;
                _moneyList.Add(money);
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

                var tempMoney = _moneyList[_moneyList.Count - 1];
                belt.SendMoneyToBank(tempMoney);
                _moneyList.Remove(tempMoney);
                _moneyYOffset-= 0.5f;
                yield return new WaitForSeconds(moneyDropDelay);
            }
            
        }

        //private IEnumerator DropMoneyCoroutineEndGame()
        
    }
}