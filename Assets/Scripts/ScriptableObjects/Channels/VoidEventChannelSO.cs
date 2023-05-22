using UnityEngine;
using UnityEngine.Events;


namespace Deege.Game.Events
{
    /// <summary>
    /// This class is used for Events that have no arguments (Example: Exit game event)
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Void Event Channel")]
    public class VoidEventChannelSO : SerializableScriptableObject
    {
        public event UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke();
        }
    }
}