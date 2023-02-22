using System;
using Datas.ValueObject;
using UnityEngine;
using Keys;

namespace Core.QuestionArea
{
    public class PlayerMovement : MonoBehaviour
    { 
        [SerializeField] private Rigidbody Rb;
        private PlayerMovementData _data;
        private bool _isReadyToMove;
        private float _horizontalInput;
        private float _clamp ;

        private void FixedUpdate()
        {
            Move();
           /* if (_isReadyToMove)
            {
                Move();
            }
            else
            {
                Stop();
            }*/
        }
        
        public void ActivateMovement()
        {
            _isReadyToMove = true;
        }

        public void DeactivateMovement()
        {
            _isReadyToMove = false;
        }

        private void Move()
        {
            Rb.velocity = new Vector3(_horizontalInput * _data.SidewaysSpeed, Rb.velocity.y, 
                _data.ForwardSpeed);
        }

        private void Stop()
        {
            Rb.velocity = Vector3.zero;
        }

        public void SetMovementData(PlayerMovementData movementData)
        {
            _data = movementData;
        }
        public void SetSideForces(HorizontalInputParams horizontalInput)
        {
            _horizontalInput = horizontalInput.XValue;

            _clamp = horizontalInput.ClampValues;

            ClampControl();
        }
        
        public void SetSideForces(float horizontalInput)
        {
            _horizontalInput = horizontalInput;
        }

        private void ClampControl()
        {
            if ((_horizontalInput < 0 && Rb.position.x <= -_clamp) || (_horizontalInput > 0 && Rb.position.x >= _clamp))
            {
                _horizontalInput = 0;
            }
        }
    }
}