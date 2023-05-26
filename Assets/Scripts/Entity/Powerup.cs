using System.Collections;
using UnityEngine;
using Deege.Game;
using System;
using Deege.Game.Events;

namespace Deege.Game.Entity
{
    /// <summary>
    /// Default Powerup class. The functionality is held in the PowerupEffectSO.
    /// </summary>
    public class Powerup : MonoBehaviour
    {

        [SerializeField] public PowerupEffectSO Effect;
        [SerializeField] public StringEventChannelSO OnPlayerPowerupCollectedEvent;

        private GameObject target;

        /// <summary>
        /// Triggered on collision. This only works on objects tagged with player.
        /// If there is a duration set, it starts a countdown for how long the effect 
        /// lasts, otherwise it is done right away and Deactivate is never called.
        /// </summary>
        /// <param name="other">the colliding gameobject</param>
        public void OnTriggerEnter(Collider other)
        {
            if (other.tag.ToLower() != "player")
            {
                return;
            }
            target = other.gameObject;
            Effect?.Apply(target);
            ReturnPowerup(gameObject);
            OnPlayerPowerupCollectedEvent.RaiseEvent(Effect?.ID);
        }

        private void ReturnPowerup(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Removes the effect from the powerup
        /// </summary>
        public void ResetActivePowerup()
        {
            Effect?.Remove(target);
        }
    }
}
