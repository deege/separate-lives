
using UnityEngine;
using Deege.Game.Events;

namespace Deege.Game
{
    [CreateAssetMenu(menuName = "Deege/Powerups/ShieldBuff")]
    public class ShieldPowerupSO : PowerupEffectSO
    {

        [SerializeField] public FloatEventChannelSO OnPlayerShieldUpEvent;
        [SerializeField] public VoidEventChannelSO OnPlayerShieldDownEvent;

        override public void Apply(GameObject target)
        {
            OnPlayerShieldUpEvent.RaiseEvent(Duration);
        }

        public override void Remove(GameObject target)
        {
            OnPlayerShieldDownEvent.RaiseEvent();
        }
    }
}