using System;
using Core.QuestionArea;
using UnityEngine;

namespace Controllers
{
    public class Money : MonoBehaviour
    {
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private Animator moneyAnim;
        public void Collect(Transform playerTransform, float moneyOffset)
        {
            boxCollider.enabled = false;
            transform.parent = playerTransform;
            transform.localPosition = Vector3.zero + (moneyOffset * Vector3.up);
            moneyAnim.enabled = false;
            moneyAnim.transform.localRotation = Quaternion.identity;
            
        }
        

       
    }
}