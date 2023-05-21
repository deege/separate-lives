using UnityEngine;
using UnityEngine.Events;

namespace Deege.Events.Game
{
    /// <summary>
    /// This class is used for Events that have one float argument.
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Float Event Channel")]
    public class FloatEventChannelSO : SerializableScriptableObject
    {
        public UnityAction<float> OnEventRaised;

        public void RaiseEvent(float value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}