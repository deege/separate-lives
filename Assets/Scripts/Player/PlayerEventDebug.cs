
using System.Collections;
using UnityEngine;
using Deege.Game.Events;


namespace Deege.Game.Player
{
    public class PlayerEventDebug : MonoBehaviour
    {

        [Header("Event Channels")]
        [SerializeField] public BoolEventChannelSO OnPlayerJumpEvent;

        void OnEnable()
        {
            if (OnPlayerJumpEvent != null)
            {
                OnPlayerJumpEvent.OnEventRaised += OnPlayerJump;
            }
        }

        void OnDisable()
        {
            if (OnPlayerJumpEvent != null)
            {
                OnPlayerJumpEvent.OnEventRaised -= OnPlayerJump;
            }
        }

        public void OnPlayerJump(bool isJumping)
        {
            // Debug.Log($"Player is jumping in debug - {OnPlayerJumpEvent.Guid}");
        }

    }
}