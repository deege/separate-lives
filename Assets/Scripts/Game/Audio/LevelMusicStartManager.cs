using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Deege.Game.Events;

namespace Deege.Game.Audio
{
    public class LevelMusicStartManager : MonoBehaviour
    {
        [SerializeField] AudioClip backgroundMusic;

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
            MusicManager.Instance.PlayMusic(backgroundMusic);
        }
    }
}
