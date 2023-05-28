using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;


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

        public void PlaySound(string name, AudioMixerGroup audioMixerGroup = null)
        {
            if (clipEntries.TryGetValue(name, out AudioClip clip))
            {
                AudioSource source = audioPool.Get();
                source.gameObject.SetActive(true);
                source.clip = clip;
                source.outputAudioMixerGroup = audioMixerGroup;
                source.Play();

                StartCoroutine(ReturnToPoolAfterPlaying(source));
            }
            else
            {
                Debug.LogError($"No clip found with name {name}");
            }
        }

        private System.Collections.IEnumerator ReturnToPoolAfterPlaying(AudioSource audioSource)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.gameObject.SetActive(false);
            audioPool.ReturnToPool(audioSource);
        }
    }
}
