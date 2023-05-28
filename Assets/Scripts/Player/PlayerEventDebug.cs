
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
                Debug.Log($"Player Jump Registered in debug - {OnPlayerJumpEvent.Guid}");
                OnPlayerJumpEvent.OnEventRaised += OnPlayerJump;
            }
        }

        void OnDisable()
        {
            if (OnPlayerJumpEvent != null)
            {
                Debug.Log($"Player Jump Removed in debug - {OnPlayerJumpEvent.Guid}");
                OnPlayerJumpEvent.OnEventRaised -= OnPlayerJump;
            }
        }

        public void OnPlayerJump(bool isJumping)
        {
            Debug.Log($"Player is jumping in debug - {OnPlayerJumpEvent.Guid}");
        }

    }
}