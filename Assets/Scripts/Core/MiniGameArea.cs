using DG.Tweening;
using Signals;
using UnityEngine;

namespace Core
{
    public class MiniGameArea : MonoBehaviour
    {
        [SerializeField] private Transform moneyDropPoint;
        private const float _endGameOffSetZ = 5f;
        private int _moneyXFactor = -1;
        private float _groundYOffset = 0.25f;
        private int moneyCounter = 0;
        

        public void SendMoneyToGround(Money money)
        {
            _moneyXFactor *= _moneyXFactor;
            moneyCounter++;
            money.transform.parent = moneyDropPoint.transform;
            money.transform.rotation = Quaternion.Euler(Vector3.zero);
            money.transform.DOMoveZ(transform.position.z + _endGameOffSetZ, .2f);
            money.transform.DOMoveX(money.transform.position.x + _moneyXFactor * 0.2f, .2f)
                .OnComplete(() =>
                    money.transform.DOLocalMoveY(  moneyCounter + _groundYOffset/3,2));
                    PlayerSignals.Instance.onGetEndGameCamToMoney?.Invoke(money.transform);
                
        }
    }
}