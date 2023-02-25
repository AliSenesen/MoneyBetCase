using Controllers;
using DG.Tweening;
using UnityEngine;

namespace Core.QuestionArea
{
    public class BetBelt : MonoBehaviour
    {
        [SerializeField] private Transform moneyBank;
        [SerializeField] private bool isLeft; 
       
       private void IncreaseBet()
        {
            
        }

        public void SendMoneyToBank(Money money)
        {
            money.transform.parent = transform;
            money.transform.DOMove(new Vector3(transform.position.x,transform.position.y+3f,money.transform.position.z), .2f, false);

            money.transform.DORotateQuaternion(isLeft ? Quaternion.Euler(0, 0, 90) : Quaternion.Euler(0, 0, -90), .2f)
                .OnComplete(() => LandOnBelt(money));
            


        }

        private void LandOnBelt(Money money)
        {
            money.transform.DOLocalMoveY(
                .6f,.2f, false);

            money.transform.DORotate(Vector3.zero, 1);
           
        }
    }
}