using UnityEngine;

namespace Deege.Game.Variables
{
    [CreateAssetMenu(fileName = "DoubleSO", menuName = "Deege/Values/DoubleVariableSO")]
    public class DoubleVariableSO : ScriptableObject
    {
        public double Value;
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public void SetValue(double value)
        {
            Value = value;
        }

        public void SetValue(DoubleVariableSO value)
        {
            Value = value.Value;
        }

        public void Add(double amount)
        {
            Value += amount;
        }

        public void Add(DoubleVariableSO amount)
        {
            Value += amount.Value;
        }
    }
}