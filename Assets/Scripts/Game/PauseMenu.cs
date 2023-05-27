using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deege.Game.Events;

namespace Deege.Game.Level
{
public class PauseMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] public GameObject pauseMenu;

    [Header("Event Channels")]
    [SerializeField] public BoolEventChannelSO OnGamePauseEvent;
    [SerializeField] public VoidEventChannelSO OnGameQuitEvent;

    void OnEnable()
    {
        if (OnGamePauseEvent != null)
        {
            OnGamePauseEvent.OnEventRaised += OnGamePauseClick;
        }
    }

    void OnDisable()
    {
        if (OnGamePauseEvent != null)
        {
            OnGamePauseEvent.OnEventRaised -= OnGamePauseClick;
        }
    }

    public void OnGamePauseClick(bool isPaused)
    {
        pauseMenu?.SetActive(isPaused);
    }

    public void OnQuitClick()
    {
        Debug.Log("Quit");
        OnGameQuitEvent?.RaiseEvent();
        Application.Quit();
    }

    public void OnResumeGameClick()
    {
        OnGamePauseEvent.RaiseEvent(false);
    }
}
}
