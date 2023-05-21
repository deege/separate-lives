using Deege.Events.Player;
using UnityEngine;

namespace Deege.Game
{
    [CreateAssetMenu(menuName = "Deege/Powerups/1Up")]
    public class OneUpPowerupSO : PowerupEffectSO
    {
        override public void Apply(GameObject target)
        {
            PlayerOneUpPowerupEvent.Trigger("1Up power up");
        }

        public override void Remove(GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
}