using System;

namespace Deege.Variables
{
    [Serializable]
    public class LongReference
    {
        public bool UseConstant = false;
        public long ConstantValue;
        public LongVariableSO Variable;

        public long Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator long(LongReference reference)
        {
            return reference.Value;
        }
    }
}