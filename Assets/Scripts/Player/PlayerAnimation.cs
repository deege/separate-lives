using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deege.Game.Events;

namespace Deege.Game.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] public BoolEventChannelSO OnPlayerIsJumpingEvent;
        [SerializeField] public BoolEventChannelSO OnPlayerIsDashingEvent;
        [SerializeField] public BoolEventChannelSO OnPlayerIsCrouchingEvent;
        [SerializeField] public BoolEventChannelSO OnPlayerIsRunningEvent;
        [SerializeField] private Animator animator;

        private void OnEnable()
        {
            if (OnPlayerIsJumpingEvent != null)
            {
                OnPlayerIsJumpingEvent.OnEventRaised += OnPlayerIsJumping;
            }
            if (OnPlayerIsDashingEvent != null)
            {
                OnPlayerIsDashingEvent.OnEventRaised += OnPlayerIsDashing;
            }
            if (OnPlayerIsCrouchingEvent != null)
            {
                OnPlayerIsCrouchingEvent.OnEventRaised += OnPlayerIsCrouching;
            }
            if (OnPlayerIsRunningEvent != null)
            {
                OnPlayerIsRunningEvent.OnEventRaised += OnPlayerIsRunning;
            }
        }

        private void OnDisable()
        {
            if (OnPlayerIsJumpingEvent != null)
            {
                OnPlayerIsJumpingEvent.OnEventRaised -= OnPlayerIsJumping;
            }
            if (OnPlayerIsDashingEvent != null)
            {
                OnPlayerIsDashingEvent.OnEventRaised -= OnPlayerIsDashing;
            }
            if (OnPlayerIsCrouchingEvent != null)
            {
                OnPlayerIsCrouchingEvent.OnEventRaised -= OnPlayerIsCrouching;
            }
            if (OnPlayerIsRunningEvent != null)
            {
                OnPlayerIsRunningEvent.OnEventRaised -= OnPlayerIsRunning;
            }
        }

        public void OnPlayerIsJumping(bool isJumping)
        {
            Debug.Log("Jumping");
            animator.SetBool("IsJumping", isJumping);
        }

        public void OnPlayerIsDashing(bool isDashing)
        {
            animator.SetBool("IsDashing", isDashing);
        }

        public void OnPlayerIsCrouching(bool isCrouching)
        {
            animator.SetBool("IsCrouching", isCrouching);
        }

        public void OnPlayerIsRunning(bool isRunning)
        {
            animator.SetBool("IsMoving", isRunning);
        }
    }
}