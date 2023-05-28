using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Deege.Game.Events;

namespace Deege.Game.Level
{
    public class ScreenStartManager : MonoBehaviour
    {
        [SerializeField] public VoidEventChannelSO OnGameStartEvent;
        [SerializeField] public VoidEventChannelSO OnLevelStartEvent;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            if (currentSceneName == "Level1")
            {
                OnGameStartEvent?.RaiseEvent();
            }
            else
            {
                OnLevelStartEvent?.RaiseEvent();
            }
        }
    }
}
