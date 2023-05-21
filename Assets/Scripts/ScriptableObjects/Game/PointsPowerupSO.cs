using Deege.Events.Score;
using UnityEngine;

namespace Deege.Game
{
    [CreateAssetMenu(menuName = "Deege/Powerups/PointsBuff")]
    public class PointsPowerupSO : PowerupEffectSO
    {
        public int Points = 0;
        override public void Apply(GameObject target)
        {
            AddScoreEvent.Trigger("Points Collected Score Event", Points);
        }

        public override void Remove(GameObject target)
        {
            throw new System.NotImplementedException();
        }
    }
}