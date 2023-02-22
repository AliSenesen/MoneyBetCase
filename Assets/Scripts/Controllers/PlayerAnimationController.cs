using System;
using Enums;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AnimationStates animState;


        private void Awake()
        {
            StartIdleAnim();
          // StartRunAnim();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }
        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += StartRunAnim;
        }
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= StartRunAnim;
        }
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void ChangeAnimationData(AnimationStates animationStates)
        {
            this.animState = animationStates;
        }

        public void StartIdleAnim()
        {
            ChangeAnimationData(AnimationStates.Idle);
            ResetAllAnims();
            animator.SetBool("Idle",true);
        }

        public void StartRunAnim()
        {
            ChangeAnimationData(AnimationStates.Run);
            ResetAllAnims();
            animator.SetBool("Run",true);
        }

        private void ResetAllAnims()
        {
            animator.SetBool("Idle",false);
            animator.SetBool("Run",false);
        }
        
    }
}