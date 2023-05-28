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


        [Header("Player Event Channels")]
        [SerializeField] public Vector2EventChannelSO OnPlayerMovementEvent;
        [SerializeField] public BoolEventChannelSO OnPlayerJumpEvent;

        private int jumpCount = 0;
        private bool isJumping = false;
        private bool isDashing = false;
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
                Debug.Log($"Registering Jump for Movement - {OnPlayerJumpEvent.Guid}");
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
            float moveSpeed = 5f; // Adjust the speed as needed
            Vector3 movement = new Vector3(rawInput.x * moveSpeed, 0f, 0f);
            transform.position += movement * Time.deltaTime;
        }

        private void JumpPlayer(bool startJump)
        {
            if (startJump && (jumpCount < 2 || !isJumping))
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
                    isDashing = true;
                }

                jumpCount++;
                isJumping = true;
            }

            if (isDashing)
            {
                rb.AddForce(dashDirection * dashForce, ForceMode.VelocityChange);
                isDashing = false;
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
                isJumping = false;
                isDashing = false;
            }
        }
    }
}