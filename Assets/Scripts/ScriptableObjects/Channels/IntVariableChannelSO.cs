#if UNITY_EDITOR
using UnityEditor;
#endif
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
        [SerializeField] private int _value;

        public void RaiseEvent(int value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }

        public int Value
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
        public void SetValue(int value)
        {
            Value = value;
        }

        public void SetValue(IntVariableSO value)
        {
            Value = value.Value;
        }

        public void Add(int amount)
        {
            Value += amount;
        }

        public void Add(IntVariableSO amount)
        {
            Value += amount.Value;
        }
    }

#if UNITY_EDITOR
[CustomEditor(typeof(IntVariableChannelSO))]
public class IntVariableChannelSOEditor : Editor
{
    private int _lastValue = 0;

    public override void OnInspectorGUI()
    {
        // Draw default inspector and get a reference to the script
        DrawDefaultInspector();
        IntVariableChannelSO script = (IntVariableChannelSO)target;

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