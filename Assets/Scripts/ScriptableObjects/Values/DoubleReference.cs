using System;

namespace Deege.Game.Variables
{

    [Serializable]
    public class DoubleReference
    {
        public bool UseConstant = false;
        public double ConstantValue;
        public DoubleVariableSO Variable;
        public double Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator double(DoubleReference reference)
        {
            return reference.Value;
        }
    }

}