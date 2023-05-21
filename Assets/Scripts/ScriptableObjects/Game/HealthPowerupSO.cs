using Deege.Events.Player;
using UnityEngine;

namespace Deege.Game
{
    [CreateAssetMenu(menuName = "Deege/Powerups/HealthBuff")]
    public class HealthPowerupSO : PowerupEffectSO
    {
        public int HealthBuff = 0;

        override public void Apply(GameObject target)
        {
            PlayerHealthPowerupEvent.Trigger("Health power up", HealthBuff);
        }

        public override void Remove(GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
}