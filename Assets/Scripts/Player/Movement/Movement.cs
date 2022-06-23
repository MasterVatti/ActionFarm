using System;
using Events;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed;
        [SerializeField]
        private Transform _transform;
        [SerializeField]
        private Animator _animator;
    
        private CompositeDisposable _subscriptions;
        private Rigidbody _characterRigidbody;



        private static readonly int _moving = Animator.StringToHash(GlobalConstants.CHARACTER_ANIMATOR_ISMOVING_PARAMETR);
        public bool IsMoving
        {
            get => _animator.GetBool(_moving);
            set => _animator.SetBool(_moving, value);
        }

        private void Awake()
        {
            _characterRigidbody = GetComponent<Rigidbody>();

            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<PlayerMovementEvent>(MovePlayer)
            };
        }

        private void MovePlayer(PlayerMovementEvent eventData)
        {
            if (eventData.Direction != Vector3.zero)
            {
                IsMoving = true;
                _transform.rotation = Quaternion.LookRotation(eventData.Direction);
                //_transform.rotation = new Quaternion(eventData.Direction.x, 0f, eventData.Direction.z, 0f);
                //eventData.Direction.x += _moveSpeed; 
                //eventData.Direction.z += _moveSpeed;
                _characterRigidbody.velocity = eventData.Direction;
                //_characterRigidbody.velocity = new Vector3(eventData.Direction.x)
            }
            else
            {
                IsMoving = false;
            }
 
        }

        private void FixedUpdate()
        {

        }

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }
    }
}