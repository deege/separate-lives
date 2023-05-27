using System.Collections;
using System.Collections.Generic;
using Deege.Game.Events;
using UnityEngine;

public class GameControlManager : MonoBehaviour
{

    [SerializeField] public BoolEventChannelSO OnGamePauseEvent;

    private void OnEnable()
    {
        OnGamePauseEvent.OnEventRaised += OnGamePause;
    }

    private void OnDisable()
    {
        OnGamePauseEvent.OnEventRaised -= OnGamePause;
    }

    public void OnGamePause(bool isPaused)
    {
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
