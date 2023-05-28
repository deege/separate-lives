using UnityEngine;
using System.Collections;

namespace Deege.Game.Audio
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager Instance { get; private set; }

        public AudioSource audioSource;
        public float transitionTime = 1f; // time for a transition to complete

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayMusic(AudioClip musicClip)
        {
            StartCoroutine(TransitionMusic(musicClip));
        }

        private IEnumerator TransitionMusic(AudioClip newClip)
        {
            float t = 0;

            float initialVolume = audioSource.volume;
            AudioClip initialClip = audioSource.clip;

            // If the AudioSource is not currently playing anything, start playing the newClip immediately
            if (initialClip == null)
            {
                audioSource.clip = newClip;
                audioSource.Play();
                yield break;
            }

            // Fade out the current track
            while (t < transitionTime)
            {
                t += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(initialVolume, 0, t / transitionTime);
                yield return null;
            }

            // Switch to the new track and start fading it in
            audioSource.clip = newClip;
            audioSource.Play();

            t = 0;
            while (t < transitionTime)
            {
                t += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(0, initialVolume, t / transitionTime);
                yield return null;
            }
        }
    }
}