using UnityEngine;
using UnityEngine.Events;
using Deege.Game.Variables;

namespace Deege.Game.Events
{
    /// <summary>
    /// This class is used for Events that have one int variable argument.
    /// Example: An health event, where the int is the current health.
    /// </summary>

    [CreateAssetMenu(menuName = "Deege/Game/Events/Int Variable Channel SO")]
    public class IntVariableChannelSO : SerializableScriptableObject
    {
        public UnityAction<int> OnEventRaised;
        private int _value;

        protected void RaiseEvent(int value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }

        public int Value
        {
            get { return _value; }
        }

#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public void SetValue(int value)
        {
            _value = value;
            RaiseEvent(Value);
        }

        public void SetValue(IntVariableSO value)
        {
            _value = value.Value;
            RaiseEvent(Value);
        }

        public void Add(int amount)
        {
            _value += amount;
            RaiseEvent(Value);
        }

        public void Add(IntVariableSO amount)
        {
            _value += amount.Value;
            RaiseEvent(Value);
        }
    }
}