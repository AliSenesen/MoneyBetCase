using System;
using System.Collections;
using Cinemachine;
using Controllers;
using Core.Player;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        

        [SerializeField] private Animator animator;
        [SerializeField] private CinemachineVirtualCamera InGameCam;
        [SerializeField] private CinemachineVirtualCamera EndGameCam;
        

       
        
        private Vector3 _inGameCamPos;
        private Vector3 _endGameCamPos;

      

        private void Start()
        {
            
            _inGameCamPos = InGameCam.transform.position;
            _endGameCamPos = EndGameCam.transform.position;
            OnPlay();
            SetAllCameraToTarget();
          
        }


        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            PlayerSignals.Instance.onPlayerEnterFinishLine += OnPlayerEnterFinishLine;

        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            PlayerSignals.Instance.onPlayerEnterFinishLine -= OnPlayerEnterFinishLine;
            
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void SetAllCameraToTarget()
        {
            SetCameraTargetToPlayer(InGameCam);
           
            
        }

        private void OnPlay()
        {
            animator.Play("InGameCam");
        }
          [Button]
        private void OnPlayerEnterFinishLine()
        {
            animator.Play("EndGameCam");
            SetCameraTargetToMoney(EndGameCam);
        }

        private void SetCameraTargetToPlayer(CinemachineVirtualCamera Camera)
        {
            Camera.Follow = GameObject.FindObjectOfType<PlayerController>().transform;
        }

        private void SetCameraTargetToMoney(CinemachineVirtualCamera Camera)
        {
            Camera.Follow = GameObject.FindObjectOfType<Money>().transform;
        }

        private IEnumerator EndGameCamera(float delay)
        {
            yield return new WaitForSeconds(delay);
            animator.Play("EndGameCam");
        }
    }
}