using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deege.Game.Events;

namespace Deege.Game.Level
{
    public class LivesBar : MonoBehaviour
    {
        [Header("Player Settings")]
        [SerializeField] public List<GameObject> Hearts;

        [Header("Event Channels")]
        [SerializeField] public IntVariableChannelSO PlayerLivesChannel;


        private void OnEnable()
        {
            if (PlayerLivesChannel != null)
            {
                PlayerLivesChannel.OnEventRaised += OnPlayerLivesChange;
            }
        }

        private void OnDisable()
        {
            if (PlayerLivesChannel != null)
            {
                PlayerLivesChannel.OnEventRaised -= OnPlayerLivesChange;
            }
        }

        // Start is called before the first frame update
        void OnPlayerLivesChange(int lives)
        {
            for (int i = 0; i < Hearts.Count; i++)
                Hearts[i].SetActive(lives > i);
        }
    }
}
