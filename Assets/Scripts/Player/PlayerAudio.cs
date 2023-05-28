
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deege.Game.Audio;
using Deege.Game.Events;

namespace Deege.Game.Player
{
    public class PlayerAudio : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] private AudioPlayer audioPlayer;

        [Header("Event Channels")]
        [SerializeField] public BoolEventChannelSO OnPlayerJumpEvent;

        void OnEnable()
        {
            if (OnPlayerJumpEvent != null)
            {
                Debug.Log($"Player Jump Registered - {OnPlayerJumpEvent.Guid}");
                OnPlayerJumpEvent.OnEventRaised += OnPlayerJump;
            }
        }

        void OnDisable()
        {
            if (OnPlayerJumpEvent != null)
            {
                Debug.Log($"Player Jump Removed - {OnPlayerJumpEvent.Guid}");
                OnPlayerJumpEvent.OnEventRaised -= OnPlayerJump;
            }
        }

        public void OnPlayerJump(bool isJumping)
        {
            Debug.Log("Player Jump Sound");
            if (isJumping)
            {
                audioPlayer.PlaySound("player_jump");
            }
        }

    }
}
