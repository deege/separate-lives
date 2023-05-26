
using UnityEngine;
using Deege.Game.Events;

namespace Deege.Game
{
    [CreateAssetMenu(menuName = "Deege/Powerups/PointsBuff")]
    public class PointsPowerupSO : PowerupEffectSO
    {
        public int Points = 0;
        public LongEventChannelSO OnAddScoreEvent;

        override public void Apply(GameObject target)
        {
            OnAddScoreEvent?.RaiseEvent(Points);
        }

        public override void Remove(GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
}