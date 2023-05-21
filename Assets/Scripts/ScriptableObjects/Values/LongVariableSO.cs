using UnityEngine;

namespace Deege.Variables
{
    [CreateAssetMenu(fileName = "LongSO", menuName = "Deege/Values/LongVariableSO")]
    public class LongVariableSO : ScriptableObject
    {
        public long Value;
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
}