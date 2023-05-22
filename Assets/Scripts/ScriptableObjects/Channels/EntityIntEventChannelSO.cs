using UnityEngine.Events;
using UnityEngine;

namespace Deege.Game.Events
{
    /// <summary>
    /// This class is used for Events that have a Vector2 argument.
    /// Example: An event to respond to movement
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Entity-Int Event Channel")]
    public class EntityIntEventChannelSO : SerializableScriptableObject
    {
        public UnityAction<GameObject, int> OnEventRaised;

        public void RaiseEvent(GameObject obj, int value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(obj, value);
        }
    }
}