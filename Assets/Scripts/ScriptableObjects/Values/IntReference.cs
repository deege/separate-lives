using System;

namespace Deege.Game.Variables
{
    [Serializable]
    public class IntReference
    {
        public bool UseConstant = false;
        public int ConstantValue;
        public IntVariableSO Variable;
        public int Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator int(IntReference reference)
        {
            return (reference != null) ? reference.Value : 0;
        }
    }
}