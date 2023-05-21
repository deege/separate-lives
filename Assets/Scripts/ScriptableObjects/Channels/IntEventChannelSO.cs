using UnityEngine;
using UnityEngine.Events;

namespace Deege.Events.Game
{
    /// <summary>
    /// This class is used for Events that have one int argument.
    /// Example: An Achievement unlock event, where the int is the Achievement ID.
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Int Event Channel")]
    public class IntEventChannelSO : SerializableScriptableObject
    {
        public UnityAction<int> OnEventRaised;

        public void RaiseEvent(int value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}