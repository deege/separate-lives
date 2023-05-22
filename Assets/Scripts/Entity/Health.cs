using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using Deege.Game;
using Deege.Game.Events;
using Deege.Game.Variables;

namespace Deege.Game.Entity
{
    public class Health : MonoBehaviour
    {
        [Header("General Settings")]
        [SerializeField] public IntVariableChannelSO CurrentHealth;
        [SerializeField] public IntReference MaxHealth;

        [Header("Entity Event Channels")]
        [SerializeField] public EntityIntEventChannelSO OnEntityHitEvent;
        [SerializeField] public GameObjectEventChannelSO OnEntityDiedEvent;

        virtual public void Awake()
        {
            string SO_PATH = "SOInstances/{0}";
            if (MaxHealth == null)
            {
                MaxHealth = new IntReference
                {
                    Variable = Instantiate(Resources.Load<IntVariableSO>(String.Format(SO_PATH, "DefaultEnemyHealthSO")))
                };
            }
            if (CurrentHealth == null)
            {
                CurrentHealth = ScriptableObject.CreateInstance<IntVariableChannelSO>();
                CurrentHealth.SetValue(MaxHealth);
            }
        }

        private void OnEnable()
        {
            if (OnEntityHitEvent != null)
            {
                OnEntityHitEvent.OnEventRaised += OnEntityHit;
            }
        }

        private void OnDisable()
        {
            if (OnEntityHitEvent != null)
            {
                OnEntityHitEvent.OnEventRaised -= OnEntityHit;
            }
        }

        public void OnEntityHit(GameObject eventType, int damageAmount)
        {
            if (eventType.GetInstanceID() == gameObject.GetInstanceID())
            {
                TakeDamage(damageAmount);
            }
        }

        /// <summary>
        /// Take damage from whatever hit this object. 
        /// </summary>
        /// <param name="damage">the amount of damage taken</param>
        public virtual void TakeDamage(int damage)
        {
            int clampedHealth = Mathf.Clamp(CurrentHealth.Value - damage, 0, Int32.MaxValue);
            CurrentHealth.SetValue(clampedHealth);
            if (CurrentHealth.Value <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// The death method for this object.
        /// </summary>
        protected void Die()
        {
            OnEntityDiedEvent.RaiseEvent(gameObject);
        }

        /// <summary>
        /// Catches collisions. 
        /// </summary>
        /// <param name="other"></param>
        protected void OnTriggerEnter(Collider other)
        {
            NotifyCollision(other);
        }

        public void NotifyCollision(Collider other)
        {
            if (other.tag.ToLower() == "garbagecollector")
            {
                return; // This is a bullet or enemy hitting the exit areas
            }
            if (other.tag.ToLower() == "powerup")
            {
                return; // This is a powerup
            }

            if (CurrentHealth.Value > 0)
            {
                int damageReceived = other.GetComponent<DamageDealer>().GetDamage();
                int damageDealt = GetComponent<DamageDealer>().GetDamage();
                if (damageReceived > 0)
                {
                    OnEntityHitEvent.RaiseEvent(gameObject, damageReceived);
                }
                if (damageDealt > 0)
                {
                    OnEntityHitEvent.RaiseEvent(other.gameObject, damageDealt);
                }
            }
        }

        /// <summary>
        /// Resets the health to maximum.
        /// </summary>
        public void ResetHealth()
        {
            CurrentHealth.SetValue(MaxHealth);
        }

        [CustomEditor(typeof(Health))]
        public class PlayerHealthEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                Health health = (Health)target;
                DrawDefaultInspector();
                GUILayout.Label("Testing", EditorStyles.boldLabel);
                if (GUILayout.Button("Reset Health"))
                {
                    health.ResetHealth();
                }
            }
        }
    }
}
