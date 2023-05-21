using UnityEngine;

namespace Deege.Variables
{
    [CreateAssetMenu(fileName = "FloatSO", menuName = "Deege/Values/FloatVariableSO")]
    public class FloatVariableSO : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public float Value;
        public void SetValue(float value)
        {
            Value = value;
        }

        public void SetValue(FloatVariableSO value)
        {
            Value = value.Value;
        }

        public void Add(float amount)
        {
            Value += amount;
        }

        public void Add(FloatVariableSO amount)
        {
            Value += amount.Value;
        }
    }
}