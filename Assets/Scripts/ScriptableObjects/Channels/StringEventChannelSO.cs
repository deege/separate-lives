using UnityEngine.Events;
using UnityEngine;

namespace Deege.Game.Events
{
    /// <summary>
    /// This class is used for Events that have a string argument.
    /// Example: An event to match a group of gameobjects by tag
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/String Event Channel")]
    public class StringEventChannelSO : SerializableScriptableObject
    {
        public UnityAction<string> OnEventRaised;

        public void RaiseEvent(string value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}