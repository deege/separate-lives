using System.Collections;
using System.Collections.Generic;
using Deege.Game.Events;
using TMPro;
using UnityEngine;

namespace Deege.Game.Level
{
    public class Scoreboard : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] TextMeshProUGUI scoreText;
        [Header("Event Channels")]
        [SerializeField] public LongVariableChannelSO CurrentScore;


        private void Start()
        {

        }

        void OnEnable()
        {
            if (CurrentScore != null)
            {
                CurrentScore.OnEventRaised += UpdateScore;
            }
        }

        void OnDisable()
        {
            if (CurrentScore != null)
            {
                CurrentScore.OnEventRaised -= UpdateScore;
            }
        }

        public void UpdateScore(long newScore)
        {
            scoreText.text = newScore.ToString("D10");
        }
    }
}
