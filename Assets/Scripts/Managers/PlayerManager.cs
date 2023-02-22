using System;
using Controllers;
using Datas.UnityObject;
using Datas.ValueObject;
using Keys;
using UnityEngine;
using Signals;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        private PlayerData _playerData;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] PlayerAnimationController playerAnimationController;


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
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            InputSignals.Instance.onInputDragged -= OnInputDragged;
            InputSignals.Instance.onInputReleased -= OnInputReleased;
            PlayerSignals.Instance.onPlayerEnterFinishLine -= OnDeactivateMovement;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void OnPlay()
        {
            _playerMovementController.ActivateMovement();
            
        }

        private void OnDeactivateMovement()
        {
            _playerMovementController.DeactivateMovement();
            playerAnimationController.StartIdleAnim();
        }

        private void SendPlayerDataToController()
        {
            _playerMovementController.SetMovementData(_playerData.PlayerMovementData);
        }

        private void OnInputDragged(HorizontalInputParams horizontalInput)
        {
            _playerMovementController.SetSideForces(horizontalInput);
        }

        private void OnInputReleased()
        {
            _playerMovementController.SetSideForces(0);
        }
    }
}