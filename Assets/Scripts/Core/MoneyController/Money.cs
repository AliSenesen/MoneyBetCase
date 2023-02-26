using System;
using Core.QuestionArea;
using UnityEngine;
using DG.Tweening;


    public class Money : MonoBehaviour
    {
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private Animator moneyAnim;
        [SerializeField] private GameObject particle;

        public void Collect(Transform moneyHolder, float moneyOffset)
        {
            moneyAnim.enabled = false;
            boxCollider.enabled = false;
            transform.parent = moneyHolder;
            transform.localPosition = Vector3.zero + (moneyOffset * Vector3.up);
            moneyAnim.transform.localRotation = Quaternion.identity;
            particle.SetActive(true);
        }
    }
