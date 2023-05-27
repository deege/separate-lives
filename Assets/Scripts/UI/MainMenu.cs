using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Deege.Game.Events;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public VoidEventChannelSO OnGameStartEvent;
    [SerializeField] public VoidEventChannelSO OnGameQuitEvent;

    public void OnPlayClick()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnQuitClick()
    {
        Debug.Log("Quit");
        OnGameQuitEvent.RaiseEvent();
        Application.Quit();
    }
}
