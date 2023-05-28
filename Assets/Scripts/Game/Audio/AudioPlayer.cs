using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Deege.Game.Audio
{

    [System.Serializable]
    public class AudioClipDictionaryEntry
    {
        public string key;
        public AudioClip value;
    }

    public class AudioPlayer : MonoBehaviour
    {

        [Header("Config")]
        public AudioPoolSO audioPool;

        [Header("Audio Clips")]
        public Dictionary<string, AudioClip> clipEntries = new Dictionary<string, AudioClip>();
        public List<AudioClipDictionaryEntry> clips;


        private void Awake()
        {
            clipEntries = clips.ToDictionary(entry => entry.key, entry => entry.value);
        }

        private void Start()
        {
            audioPool?.Initialize(transform);
        }

        public void PlaySound(string clipName)
        {
            if (clipEntries.ContainsKey(clipName.ToLower()))
            {
                AudioSource audioSource = audioPool.GetAudioSource();
                if (audioSource != null)
                {
                    audioSource.clip = clipEntries[clipName];
                    audioSource.Play();

                    StartCoroutine(ReturnToPoolAfterPlaying(audioSource));
                }
            }
            else
            {
                Debug.LogWarning($"{clipName} could not be found in the AudioPlayer");
            }
        }

        private System.Collections.IEnumerator ReturnToPoolAfterPlaying(AudioSource audioSource)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
            audioPool.ReturnToPool(audioSource);
        }
    }
}
