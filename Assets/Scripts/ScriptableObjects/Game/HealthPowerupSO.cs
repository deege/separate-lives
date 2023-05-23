
using UnityEngine;

using Deege.Game.Events;

namespace Deege.Game
{
    [CreateAssetMenu(menuName = "Deege/Powerups/HealthBuff")]
    public class HealthPowerupSO : PowerupEffectSO
    {
        public int HealthBuff = 0;
        public IntEventChannelSO OnPlayerHealthPowerupEvent;

        override public void Apply(GameObject target)
        {
            OnPlayerHealthPowerupEvent.RaiseEvent(HealthBuff);
        }

        public override void Remove(GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
}