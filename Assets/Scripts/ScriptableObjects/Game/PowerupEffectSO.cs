using UnityEngine;

namespace Deege.Game
{
    public abstract class PowerupEffectSO : ScriptableObject
    {
        public float Duration = 0.0f;
        public string ID;
        public abstract void Apply(GameObject target);
        public abstract void Remove(GameObject target);

        public override string ToString()
        {
            return base.ToString() + " Duration: " + Duration;
        }
    }
}