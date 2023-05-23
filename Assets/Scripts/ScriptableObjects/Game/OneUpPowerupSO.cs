
using UnityEngine;
using Deege.Game.Events;
namespace Deege.Game
{
    [CreateAssetMenu(menuName = "Deege/Powerups/1Up")]
    public class OneUpPowerupSO : PowerupEffectSO
    {

        public VoidEventChannelSO OnPlayerOneUpPowerupEvent;

        override public void Apply(GameObject target)
        {
            OnPlayerOneUpPowerupEvent.RaiseEvent();
        }

        public override void Remove(GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
}