using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Deege.Game.Events;

namespace Deege.Game.Level
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] public IntTripleEventChannelSO OnPlayerHealthEvent;
        [SerializeField] public Slider slider;

        private void OnEnable()
        {
            if (OnPlayerHealthEvent != null)
            {
                OnPlayerHealthEvent.OnEventRaised += OnPlayerHealthChange;
            }
        }

        private void OnDisable()
        {
            if (OnPlayerHealthEvent != null)
            {
                OnPlayerHealthEvent.OnEventRaised -= OnPlayerHealthChange;
            }
        }

        private void OnPlayerHealthChange(int oldHealth, int newHealth, int maxHealth)
        {
            float normalizedVal = Normalize(newHealth, 0, maxHealth);
            slider.value = normalizedVal;
        }

        float Normalize(float value, float min, float max)
        {
            return (value - min) / (max - min);
        }
    }
}
