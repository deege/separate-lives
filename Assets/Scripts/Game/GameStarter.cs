using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deege.Game.Audio;

namespace Deege.Game.Level
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private AudioClip startMusic;

        void Start()
        {
            MusicManager.Instance.PlayMusic(startMusic);
        }
    }
}
