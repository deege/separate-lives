using UnityEngine;
using UnityEngine.Events;

namespace Deege.Game.Events
{
    /// <summary>
    /// This class is used for Events that have three int arguments.
    /// Example: A player health event that includes max, before and after values.
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Int-Triple Event Channel")]
    public class IntTripleEventChannelSO : SerializableScriptableObject
    {
        public UnityAction<int, int, int> OnEventRaised;

        public void RaiseEvent(int value1, int value2, int value3)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value1, value2, value3);
        }
    }
}