using SimpleEventBus.Events;
using UnityEngine;

namespace Events
{
    public class PlayerMovementEvent : EventBase
    {
        public Vector3 Direction;
        public bool IsRun;
        
        public PlayerMovementEvent(Vector3 direction, bool isRun)
        {
            Direction = direction;
            IsRun = isRun;
        }
    }
}