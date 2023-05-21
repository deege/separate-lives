using Deege.Events.Player;
using UnityEngine;

namespace Deege.Game
{
    [CreateAssetMenu(menuName = "Deege/Powerups/ShieldBuff")]
    public class ShieldPowerupSO : PowerupEffectSO
    {

        override public void Apply(GameObject target)
        {
            PlayerShieldsUpEvent.Trigger("Player Shields Up Event", Duration);
        }

        public override void Remove(GameObject target)
        {
            PlayerShieldsDownEvent.Trigger("Player Shields Down Event");
        }
    }
}