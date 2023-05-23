using UnityEngine;
using UnityEngine.Events;

namespace Deege.Game.Events
{
    /// <summary>
    /// This class is used for Events that have one GameControl argument.
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Game Control Event Channel")]
    public class GameControlChannelSO : SerializableScriptableObject
    {
        public UnityAction<GameControl> OnEventRaised;

        public void RaiseEvent(GameControl value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}