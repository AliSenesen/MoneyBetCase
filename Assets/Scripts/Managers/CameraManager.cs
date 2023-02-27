using System;
using System.Collections;
using Cinemachine;
using Controllers;
using Core.Player;
using Enums;
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
            PlayerSignals.Instance.onGetEndGameCamToMoney += OnGetEndGameCamToMoney;

        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            PlayerSignals.Instance.onPlayerEnterFinishLine -= OnPlayerEnterFinishLine;
            PlayerSignals.Instance.onGetEndGameCamToMoney -= OnGetEndGameCamToMoney;
            
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
            animator.Play(CameraStates.InGameCam.ToString());
        }
          [Button]
        private void OnPlayerEnterFinishLine()
        {
            animator.Play(CameraStates.EndGameCam.ToString());
           
        }
        private void OnGetEndGameCamToMoney(Transform moneyTransform)
        {
            EndGameCam.Follow = moneyTransform;

        }

        private void SetCameraTargetToPlayer(CinemachineVirtualCamera Camera)
        {
            Camera.Follow = GameObject.FindObjectOfType<PlayerController>().transform;
        }

    }
}