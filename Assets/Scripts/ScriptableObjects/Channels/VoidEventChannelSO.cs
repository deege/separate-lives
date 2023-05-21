using UnityEngine;
using UnityEngine.Events;


namespace Deege.Events.Game
{
    /// <summary>
    /// This class is used for Events that have no arguments (Example: Exit game event)
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Void Event Channel")]
    public class VoidEventChannelSO : SerializableScriptableObject
    {
        public UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke();
        }
    }
}