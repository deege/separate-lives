using UnityEngine;
using UnityEngine.Events;

namespace Deege.Game.Events
{
    /// <summary>
    /// This class is used for Events that have one int argument.
    /// Example: An Achievement unlock event, where the int is the Achievement ID.
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Int Event Channel")]
    public class IntEventChannelSO : SerializableScriptableObject
    {
        public event UnityAction<int> OnEventRaised;

        public void RaiseEvent(int value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}