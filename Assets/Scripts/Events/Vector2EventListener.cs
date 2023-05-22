using UnityEngine;
using UnityEngine.Events;

namespace Deege.Game.Events
{
    /// <summary>
    /// To use a generic UnityEvent type you must override the generic type.
    /// </summary>
    [System.Serializable]
    public class Vector2Event : UnityEvent<Vector2>
    {

    }

    /// <summary>
    /// A flexible handler for Vector2 events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
    /// </summary>
    public class Vector2EventListener : MonoBehaviour
    {
        [SerializeField] private Vector2EventChannelSO _channel = default;

        public Vector2Event OnEventRaised;

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

        private void Respond(Vector2 value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}