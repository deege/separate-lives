using UnityEngine;
using UnityEngine.Events;

namespace Deege.Events.Game
{
    /// <summary>
    /// To use a generic UnityEvent type you must override the generic type.
    /// </summary>
    [System.Serializable]
    public class FloatEvent : UnityEvent<float>
    {

    }

    /// <summary>
    /// A flexible handler for int events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
    /// </summary>
    public class FloatEventListener : MonoBehaviour
    {
        [SerializeField] private FloatEventChannelSO _channel = default;

        public FloatEvent OnEventRaised;

        private void OnEnable()
        {
            if (_channel != null)
                _channel.OnEventRaised += Respond;
        }

        private void OnDisable()
        {
            if (_channel != null)
                _channel.OnEventRaised -= Respond;
        }

        private void Respond(float value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}