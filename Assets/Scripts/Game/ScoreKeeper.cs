using System;
using Deege.Game.Events;
using Deege.Game.Variables;
using UnityEngine;

namespace Deege.Game.Level
{
    public class ScoreKeeper : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] public LongReference InitialScore;
        [SerializeField] public LongVariableChannelSO CurrentScore;

        [SerializeField] public IntReference InitialLives;
        [SerializeField] public IntVariableSO CurrentLives;

        [Header("Event Channels")]
        [SerializeField] public LongEventChannelSO OnAddScoreEvent;
        [SerializeField] public VoidEventChannelSO OnGameStartEvent;

        void OnEnable()
        {
            if (OnAddScoreEvent != null)
            {
                OnAddScoreEvent.OnEventRaised += AddScore;
            }
            if (OnGameStartEvent != null)
            {
                OnGameStartEvent.OnEventRaised += ResetScore;
            }
        }

        void OnDisable()
        {
            if (OnAddScoreEvent != null)
            {
                OnAddScoreEvent.OnEventRaised -= AddScore;
            }
            if (OnGameStartEvent != null)
            {
                OnGameStartEvent.OnEventRaised -= ResetScore;
            }
        }

        public void SetScore(long score)
        {
            CurrentScore.SetValue(score);
        }

        public void AddScore(long addition)
        {
            CurrentScore.Add(addition);
        }

        public void ResetScore()
        {
            SetScore(InitialScore);
        }
    }
}