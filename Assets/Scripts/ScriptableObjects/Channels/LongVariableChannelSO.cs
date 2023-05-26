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
        [SerializeField] private long _value;

        public void RaiseEvent(long value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }

        public long Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaiseEvent(_value);
            }
        }

#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public void SetValue(long value)
        {
            Value = value;
        }

        public void SetValue(LongVariableSO value)
        {
            Value = value.Value;
        }

        public void Add(long amount)
        {
            Value += amount;
        }

        public void Add(LongVariableSO amount)
        {
            Value += amount.Value;
        }
    }

#if UNITY_EDITOR
[CustomEditor(typeof(LongVariableChannelSO))]
public class LongVariableChannelSOEditor : Editor
{
    private long _lastValue = 0;

    public override void OnInspectorGUI()
    {
        // Draw default inspector and get a reference to the script
        DrawDefaultInspector();
        LongVariableChannelSO script = (LongVariableChannelSO)target;

        // Check if value changed
        if (_lastValue != script.Value)
        {
            _lastValue = script.Value;
            script.RaiseEvent(_lastValue); // If value changed, raise the event
        }
    }
}
#endif
}