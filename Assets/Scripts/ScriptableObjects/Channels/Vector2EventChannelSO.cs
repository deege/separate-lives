using UnityEngine.Events;
using UnityEngine;

namespace Deege.Events.Game
{
    /// <summary>
    /// This class is used for Events that have a Vector2 argument.
    /// Example: An event to respond to movement
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Vector2 Event Channel")]
    public class Vector2EventChannelSO : SerializableScriptableObject
    {
        public UnityAction<Vector2> OnEventRaised;

        public void RaiseEvent(Vector2 value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}