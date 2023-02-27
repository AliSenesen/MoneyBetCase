using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class MiniGameArea : MonoBehaviour
    {
        [SerializeField] private Transform moneyDropPoint;
        
        public void SendMoneyToGround( Money money)
        {
            money.transform.parent = transform;
            money.transform.DOMoveZ(5, .2f, false) .
                OnComplete(() =>money.transform.DOMoveY(moneyDropPoint.transform.position.y,5)) ;

           
        }
    }
}