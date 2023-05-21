using System;

namespace Deege.Variables
{
    [Serializable]
    public class FloatReference
    {
        public bool UseConstant = false;
        public float ConstantValue;
        public FloatVariableSO Variable;
        public float Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}