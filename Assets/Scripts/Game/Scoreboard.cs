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

        void OnEnable()
        {
            if (CurrentScore != null)
            {
                CurrentScore.OnEventRaised += OnUpdateScore;
            }
        }

        void OnDisable()
        {
            if (CurrentScore != null)
            {
                CurrentScore.OnEventRaised -= OnUpdateScore;
            }
        }

        public void OnUpdateScore(long newScore)
        {
            Debug.Log("In UpdateScore");
            scoreText.text = newScore.ToString("D10");
        }
    }
}
