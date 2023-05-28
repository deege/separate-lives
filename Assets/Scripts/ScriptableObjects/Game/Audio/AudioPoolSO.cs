using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Deege.Game.Audio
{
    [CreateAssetMenu(fileName = "AudioPoolSO", menuName = "Deege/Game/Audio Pool", order = 0)]
    public class AudioPoolSO : ScriptableObject
    {
        [SerializeField] private int poolSize = 10;
        [SerializeField] private AudioSource audioPrefab;
        [SerializeField] private AudioMixerGroup mixerGroup;
        private Queue<AudioSource> audioPool = new Queue<AudioSource>();

        public void Initialize(Transform parentTransform)
        {
            for (int i = 0; i < poolSize; i++)
            {
                AudioSource newAudioSource = Instantiate(audioPrefab, parentTransform);
                newAudioSource.outputAudioMixerGroup = mixerGroup;
                newAudioSource.gameObject.SetActive(false);

                audioPool.Enqueue(newAudioSource);
            }
        }

        public AudioSource GetAudioSource()
        {
            if (audioPool.Count == 0)
            {
                Debug.LogWarning("Pool is empty!");
                return null;
            }

            AudioSource audioSource = audioPool.Dequeue();
            audioSource.gameObject.SetActive(true);

            return audioSource;
        }

        public void ReturnToPool(AudioSource audioSource)
        {
            audioSource.gameObject.SetActive(false);
            audioPool.Enqueue(audioSource);
        }
    }
}