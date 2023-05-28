using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Deege.Game.Audio
{
    [CreateAssetMenu(fileName = "AudioPoolSO", menuName = "Deege/Game/Audio Pool", order = 0)]
    public class AudioPoolSO : ScriptableObject
    {
        [SerializeField] private int poolSize = 20;
        [SerializeField] private AudioSource audioPrefab;
        [SerializeField] private AudioMixerGroup mixerGroup;
        private Queue<AudioSource> audioPool = new Queue<AudioSource>();

        private Transform originalParentTransform;


        public void Initialize(Transform parentTransform)
        {
            Debug.Log("Calling Initialize");
            Debug.Log($"Initialize was called by {new System.Diagnostics.StackTrace()}");
            originalParentTransform = parentTransform;

            for (int i = 0; i < poolSize; i++)
            {
                AudioSource newAudioSource = Instantiate(audioPrefab, originalParentTransform);
                newAudioSource.outputAudioMixerGroup = mixerGroup;
                newAudioSource.gameObject.SetActive(false);

                audioPool.Enqueue(newAudioSource);
            }
        }

        public AudioSource Get()
        {
            if (audioPool.Count == 0)
            {
                Debug.LogWarning("Pool is empty!");
                AudioSource newAudioSource = Instantiate(audioPrefab, originalParentTransform);
                newAudioSource.outputAudioMixerGroup = mixerGroup;
                newAudioSource.gameObject.SetActive(false);
                audioPool.Enqueue(newAudioSource);
            }

            AudioSource audioSource = audioPool.Dequeue();
            audioSource.gameObject.SetActive(true);

            return audioSource;
        }

        public void ReturnToPool(AudioSource audioSource)
        {
            audioSource.Stop();
            audioSource.gameObject.SetActive(false);
            audioPool.Enqueue(audioSource);
        }
    }
}