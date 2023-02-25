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
           // SetAllCameraToTarget();
          
        }


        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            //  CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
            //   CoreGameSignals.Instance.onCameraInitialized += OnCameraInitialized;
            //    CoreGameSignals.Instance.onGameEnd += OnEndGameSideCamera;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            //  CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
            // CoreGameSignals.Instance.onCameraInitialized -= OnCameraInitialized;
            // CoreGameSignals.Instance.onGameEnd -= OnEndGameSideCamera;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }


        private void OnCameraInitialized()
        {
            // PreStartCam.transform.position = _preStartCamPos;
            InGameCam.transform.position = _inGameCamPos;
            EndGameCam.transform.position = _endGameCamPos;
            SetAllCameraToTarget();
        }

        private void SetAllCameraToTarget()
        {
            SetCameraTargetToPlayer(InGameCam);

            // EndGameCam.Follow = playerFinish;
        }

        private void OnPlay()
        {
            animator.Play("InGameCam");
        }
          [Button]
        private void Anan31()
        {
            animator.Play("EndGameCam");
        }

        private void SetCameraTargetToPlayer(CinemachineVirtualCamera Camera)
        {
            Camera.Follow = GameObject.FindObjectOfType<PlayerController>().transform;
        }

        private void OnLevelSuccessful()
        {
            StartCoroutine(EndGameCamera(1));
        }

        private IEnumerator EndGameCamera(float delay)
        {
            yield return new WaitForSeconds(delay);
            animator.Play("EndGameCam");
        }
    }
}