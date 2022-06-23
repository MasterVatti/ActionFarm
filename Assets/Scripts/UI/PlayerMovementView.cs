using Events;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace UI
{
    public class PlayerMovementView : MonoBehaviour
    {
        [SerializeField]
        private FloatingJoystick _joystick;

        private void FixedUpdate()
        {
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                var direction = new Vector3(-_joystick.Vertical, 0, _joystick.Horizontal);

                EventStreams.UserInterface.Publish(new PlayerMovementEvent(direction, true));
            }
            else
            {
                EventStreams.UserInterface.Publish(new PlayerMovementEvent(Vector3.zero, false));
            }
        }
    }
}