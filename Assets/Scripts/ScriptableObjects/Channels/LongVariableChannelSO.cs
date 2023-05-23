#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;
using Deege.Game.Variables;

namespace Deege.Game.Events
{
    /// <summary>
    /// This class is used for Events that have one long variable argument.
    /// Example: An score event, where the long is the current total score.
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Long Variable Channel SO")]
    public class LongVariableChannelSO : SerializableScriptableObject
    {
        public UnityAction<long> OnEventRaised;
        private long _value;

        protected void RaiseEvent(long value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }

        public long Value
        {
            get { return _value; }
        }

#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public void SetValue(long value)
        {
            _value = value;
            RaiseEvent(Value);
        }

        public void SetValue(LongVariableSO value)
        {
            _value = value.Value;
            RaiseEvent(Value);
        }

        public void Add(long amount)
        {
            _value += amount;
            RaiseEvent(Value);
        }

        public void Add(LongVariableSO amount)
        {
            _value += amount.Value;
            RaiseEvent(Value);
        }
    }
}