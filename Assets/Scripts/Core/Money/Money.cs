using System;
using Core.QuestionArea;
using UnityEngine;
using DG.Tweening;

namespace Controllers
{
    public class Money : MonoBehaviour
    {
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private Animator moneyAnim;
        [SerializeField] private GameObject particle;

        public void Collect(Transform playerTransform, float moneyOffset)
        {
            boxCollider.enabled = false;
            transform.parent = playerTransform;
            transform.localPosition = Vector3.zero + (moneyOffset * Vector3.up);
            moneyAnim.transform.localRotation = Quaternion.identity;
            particle.SetActive(true);
        }
    }
}