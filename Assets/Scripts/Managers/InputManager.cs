using System;
using Keys;
using Signals;
using UnityEngine;


namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private FixedJoystick fixedJoystick;

        private void Update()
        {
            MouseInputs();
        }
        private void MouseInputs()
        {
            
            {
                if (fixedJoystick.Horizontal > 0.1f || fixedJoystick.Horizontal < -0.1f)
                {
                    InputSignals.Instance.onInputDragged?.Invoke(new HorizontalInputParams()
                    {
                        XValue = fixedJoystick.Horizontal,
                        ClampValues = 3.5f
                    });
                }

                if (fixedJoystick.Horizontal == 0f)
                {
                    InputSignals.Instance.onInputReleased?.Invoke();
                }
            }
        }
    }
}