using UnityEngine.Events;
using UnityEngine;

namespace Deege.Events.Game
{
    /// <summary>
    /// This class is used for Events that have a bool argument.
    /// Example: An event to toggle a UI interface
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Bool Event Channel")]
    public class BoolEventChannelSO : SerializableScriptableObject
    {
        public UnityAction<bool> OnEventRaised;

        public void RaiseEvent(bool value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}