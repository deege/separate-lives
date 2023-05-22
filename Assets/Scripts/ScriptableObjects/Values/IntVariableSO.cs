using UnityEngine;

namespace Deege.Game.Variables
{
    [CreateAssetMenu(fileName = "IntSO", menuName = "Deege/Values/IntVariableSO")]
    public class IntVariableSO : ScriptableObject
    {
        public int Value;
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
}