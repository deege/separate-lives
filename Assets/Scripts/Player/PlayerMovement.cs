using UnityEngine;
using System;
using UnityEditor;
using Deege.Game.Events;

namespace Deege.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {

        [Header("Player Settings")]
        [SerializeField] public float moveSpeed = 5.0f;

        [SerializeField] public float jumpForce = 8.0f;
        [SerializeField] public float secondJumpForce = 4.0f;
        [SerializeField] public float dashForce = 10.0f;
        [SerializeField] public float rotationSpeed;

        [Header("Player Event Channels")]
        [SerializeField] public Vector2EventChannelSO OnPlayerMovementEvent;
        [SerializeField] public BoolEventChannelSO OnPlayerJumpEvent;

        [SerializeField] public BoolEventChannelSO OnPlayerIsJumpingEvent;
        [SerializeField] public BoolEventChannelSO OnPlayerIsDashingEvent;
        [SerializeField] public BoolEventChannelSO OnPlayerIsCrouchingEvent;
        [SerializeField] public BoolEventChannelSO OnPlayerIsRunningEvent;

        private int jumpCount = 0;
        private bool isJumping = false;

        public bool IsJumping
        {
            get { return isJumping; }
            set
            {
                if (isJumping != value)
                {
                    isJumping = value;
                    Debug.Log("Raising event Jumping");
                    OnPlayerIsJumpingEvent?.RaiseEvent(isJumping);
                }
            }
        }
        private bool isDashing = false;

        public bool IsDashing
        {
            get { return isDashing; }
            set
            {
                if (isDashing != value)
                {
                    isDashing = value;
                    OnPlayerIsDashingEvent?.RaiseEvent(true);
                }
            }
        }

        private bool isCrouching = false;

        public bool IsCrouching
        {
            get { return isCrouching; }
            set
            {
                if (isCrouching != value)
                {
                    isCrouching = value;
                    OnPlayerIsCrouchingEvent?.RaiseEvent(isCrouching);
                }
            }
        }

        private Vector3 dashDirection;


        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            if (OnPlayerMovementEvent != null)
            {
                OnPlayerMovementEvent.OnEventRaised += OnPlayerMove;
            }
            if (OnPlayerJumpEvent != null)
            {
                OnPlayerJumpEvent.OnEventRaised = OnPlayerJump;
            }
        }

        private void OnDisable()
        {
            if (OnPlayerMovementEvent != null)
            {
                OnPlayerMovementEvent.OnEventRaised -= OnPlayerMove;
            }
            if (OnPlayerJumpEvent != null)
            {
                OnPlayerJumpEvent.OnEventRaised -= OnPlayerJump;
            }
        }

        private void MovePlayer(Vector2 rawInput)
        {
            Vector3 movement = new Vector3(rawInput.x * moveSpeed, 0f, 0f);
            transform.position += movement * Time.deltaTime;
            OnPlayerIsRunningEvent.RaiseEvent(rawInput.x != 0);
            if (rawInput.x > 0)
            {
                transform.eulerAngles = new Vector3(0, 90, 0); // Face right
            }
            else if (rawInput.x < 0)
            {
                transform.eulerAngles = new Vector3(0, -90, 0); // Face left
            }
            else if (rawInput.x == 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0); // Idle
            }
        }

        private void JumpPlayer(bool startJump)
        {
            if (startJump && (jumpCount < 2 || !IsJumping))
            {
                if (jumpCount == 0)
                {
                    // First jump
                    rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
                }
                else if (jumpCount == 1)
                {
                    // Second jump
                    rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z); // Reset vertical velocity before jumping
                    rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);

                    // Store the direction of movement
                    dashDirection = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z).normalized;
                    IsDashing = true;
                }

                jumpCount++;
                IsJumping = true;
            }

            if (IsDashing)
            {
                rb.AddForce(dashDirection * dashForce, ForceMode.VelocityChange);
                IsDashing = false;
            }
        }

        public void OnPlayerMove(Vector2 rawMovement)
        {
            MovePlayer(rawMovement);
        }

        public void OnPlayerJump(bool isJumping)
        {
            JumpPlayer(isJumping);
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Reset jump count when the player lands on the ground or any other surface that allows jumping
            if (collision.gameObject.CompareTag("Ground")) // Replace "Ground" with the appropriate tag for your ground objects
            {
                jumpCount = 0;
                IsJumping = false;
                IsDashing = false;
            }
        }
    }
}