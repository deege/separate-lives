using UnityEngine;
using UnityEngine.Events;

namespace Deege.Events.Game
{
    /// <summary>
    /// To use a generic UnityEvent type you must override the generic type.
    /// </summary>
    [System.Serializable]
    public class GameObjectEvent : UnityEvent<GameObject>
    {

    }

    /// <summary>
    /// A flexible handler for GameObject events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
    /// </summary>
    public class GameObjectEventListener : MonoBehaviour
    {
        [SerializeField] private GameObjectEventChannelSO _channel = default;

        public GameObjectEvent OnEventRaised;

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

        private void Respond(GameObject value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}