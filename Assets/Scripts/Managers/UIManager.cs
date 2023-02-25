using System;
using System.Collections.Generic;
using Controllers;
using Core.QuestionArea;
using Signals;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> panels;
        [SerializeField] private Animator animator;
      

        private void Start()
        {
            animator.SetTrigger("FIRST");
        }
        public void OnGameOpen()
        {
           CoreGameSignals.Instance.onPlay?.Invoke();
           animator.SetTrigger("OUT");
           panels[0].SetActive(false);
          
            
        }


    }
}