using UnityEngine;
using UnityEngine.Events;

namespace Deege.Game.Events
{
    /// <summary>
    /// This class is used for Events that have one long argument.
    /// Example: An score event, where the long is the amount scored.
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Long Event Channel")]
    public class LongEventChannelSO : SerializableScriptableObject
    {
        public event UnityAction<long> OnEventRaised;

        public void RaiseEvent(long value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}