using System;
using System.Collections.Generic;
using Controllers;
using Core.QuestionArea;
using Datas.UnityObject;
using Datas.ValueObject;
using Keys;
using UnityEngine;
using Signals;

namespace Core.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerData _playerData;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] PlayerAnimations playerAnimations;


        private void Awake()
        {
            _playerData = GetPlayerData();
            SendPlayerDataToController();
        }

        private PlayerData GetPlayerData() => Resources.Load<CD_Player>("Datas/UnityObjects/CD_Player").Data;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            InputSignals.Instance.onInputDragged += OnInputDragged;
            InputSignals.Instance.onInputReleased += OnInputReleased;
            PlayerSignals.Instance.onPlayerEnterFinishLine += OnDeactivateMovement;
            PlayerSignals.Instance.playerXPos += ReturnXPos;
            
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            InputSignals.Instance.onInputDragged -= OnInputDragged;
            InputSignals.Instance.onInputReleased -= OnInputReleased;
            PlayerSignals.Instance.onPlayerEnterFinishLine -= OnDeactivateMovement;
            PlayerSignals.Instance.playerXPos -= ReturnXPos;
            
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
        private float ReturnXPos() => transform.position.x;

        private void OnPlay()
        {
            playerMovement.ActivateMovement();
            
        }

       
        private void OnDeactivateMovement()
        {
            playerMovement.DeactivateMovement();
            playerAnimations.StartIdleAnim();
            
        }

        private void SendPlayerDataToController()
        {
            playerMovement.SetMovementData(_playerData.PlayerMovementData);
        }

        private void OnInputDragged(HorizontalInputParams horizontalInput)
        {
            playerMovement.SetSideForces(horizontalInput);
        }

        private void OnInputReleased()
        {
            playerMovement.SetSideForces(0);
        }

        



    }
}