
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
        [SerializeField] public VoidEventChannelSO OnPlayerSwitchButtonPressedEvent;

        void OnEnable()
        {
            if (OnPlayerJumpEvent != null)
            {
                OnPlayerJumpEvent.OnEventRaised += OnPlayerJump;
            }
            if (OnPlayerSwitchButtonPressedEvent != null)
            {
                OnPlayerSwitchButtonPressedEvent.OnEventRaised += OnPlayerSwitch;
            }
        }

        void OnDisable()
        {
            if (OnPlayerJumpEvent != null)
            {
                OnPlayerJumpEvent.OnEventRaised -= OnPlayerJump;
            }
            if (OnPlayerSwitchButtonPressedEvent != null)
            {
                OnPlayerSwitchButtonPressedEvent.OnEventRaised -= OnPlayerSwitch;
            }
        }

        public void OnPlayerJump(bool isJumping)
        {
            if (isJumping)
            {
                audioPlayer.PlaySound("player_jump");
            }
        }

        public void OnPlayerSwitch()
        {
            audioPlayer.PlaySound("player_switch");
        }

    }
}
