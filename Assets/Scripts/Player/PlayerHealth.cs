using System;

using UnityEngine;
using UnityEditor;

using Deege.Game.Variables;
using Deege.Game.Entity;
using Deege.Game.Events;

namespace Deege.Game.Player
{
    public class PlayerHealth : Health
    {
        [Header("Player Settings")]
        [SerializeField] public IntVariableChannelSO PlayerLivesChannel;
        [SerializeField] public IntReference MaxPlayerLives;



        [Header("Entity Event Channels")]
        [SerializeField] public IntEventChannelSO OnPlayerHealth;
        [SerializeField] public IntEventChannelSO OnPlayerHitEvent;
        [SerializeField] public GameObjectEventChannelSO OnPlayerDeathEvent;
        [SerializeField] public GameObjectEventChannelSO OnEntityDeathEvent;
        [SerializeField] public VoidEventChannelSO OnPlayerGameResetEvent;
        [SerializeField] public IntTripleEventChannelSO OnPlayerHealthEvent;
        [SerializeField] public VoidEventChannelSO OnPlayerShieldUpEvent;
        [SerializeField] public VoidEventChannelSO OnPlayerShieldDownEvent;
        [SerializeField] public VoidEventChannelSO OnPlayerSpawnEvent;
        [SerializeField] public VoidEventChannelSO OnPlayerResetEvent;
        [SerializeField] public IntEventChannelSO OnPlayerHealthPowerupEvent;
        [SerializeField] public VoidEventChannelSO OnPlayerOneUpPowerupEvent;
        [SerializeField] public VoidEventChannelSO OnGameOverEvent;
        [SerializeField] public VoidEventChannelSO OnLevelRestartLastCheckpointEvent;

        [SerializeField] public bool isShielded = false;

        /// <summary>
        /// 
        /// </summary>
        public override void Awake()
        {
            var SO_PATH = "SOInstances/{0}";
            if (MaxHealth == null)
            {
                MaxHealth = new IntReference
                {
                    Variable = Instantiate(Resources.Load<IntVariableSO>(String.Format(SO_PATH, "PlayerMaxHealthSO")))
                };
            }
            if (CurrentHealth == null)
            {
                CurrentHealth = Instantiate(Resources.Load<IntVariableChannelSO>(String.Format(SO_PATH, "PlayerHealthSO")));
            }
            if (MaxPlayerLives == null)
            {
                MaxPlayerLives = new IntReference
                {
                    Variable = Instantiate(Resources.Load<IntVariableSO>(String.Format(SO_PATH, "PlayerMaxLivesSO")))
                };
            }
            if (PlayerLivesChannel == null)
            {
                PlayerLivesChannel = Instantiate(Resources.Load<IntVariableChannelSO>(String.Format(SO_PATH, "PlayerLivesChannelSO")));
            }

            base.Awake();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            OnPlayerGameResetEvent?.RaiseEvent();
        }

        private void OnEnable()
        {
            if (OnPlayerDeathEvent != null)
            {
                OnPlayerDeathEvent.OnEventRaised += OnPlayerDeath;
            }
            if (OnPlayerShieldUpEvent != null)
            {
                OnPlayerShieldUpEvent.OnEventRaised += OnShieldsUp;
            }
            if (OnPlayerShieldDownEvent != null)
            {
                OnPlayerShieldDownEvent.OnEventRaised += OnShieldsDown;
            }
            if (OnPlayerSpawnEvent != null)
            {
                OnPlayerSpawnEvent.OnEventRaised += OnPlayerSpawn;
            }
            if (OnPlayerResetEvent != null)
            {
                OnPlayerResetEvent.OnEventRaised += OnPlayerReset;
            }
            if (OnPlayerGameResetEvent != null)
            {
                OnPlayerGameResetEvent.OnEventRaised += OnPlayerGameReset;
            }
            if (OnPlayerHealthPowerupEvent != null)
            {
                OnPlayerHealthPowerupEvent.OnEventRaised += OnPlayerHealthPowerup;
            }
            if (OnPlayerOneUpPowerupEvent != null)
            {
                OnPlayerOneUpPowerupEvent.OnEventRaised += OnPlayerOneUpPowerup;
            }
            if (OnEntityHitEvent != null)
            {
                OnEntityHitEvent.OnEventRaised += OnPlayerEntityHit;
            }
            if (OnEntityDeathEvent != null)
            {
                OnEntityDeathEvent.OnEventRaised += OnEntityDeath;
            }
            if (PlayerLivesChannel != null)
            {
                PlayerLivesChannel.OnEventRaised += OnPlayerLivesChange;
            }
        }

        private void OnDisable()
        {
            if (OnPlayerDeathEvent != null)
            {
                OnPlayerDeathEvent.OnEventRaised -= OnPlayerDeath;
            }
            if (OnPlayerShieldUpEvent != null)
            {
                OnPlayerShieldUpEvent.OnEventRaised -= OnShieldsUp;
            }
            if (OnPlayerShieldDownEvent != null)
            {
                OnPlayerShieldDownEvent.OnEventRaised -= OnShieldsDown;
            }
            if (OnPlayerSpawnEvent != null)
            {
                OnPlayerSpawnEvent.OnEventRaised -= OnPlayerSpawn;
            }
            if (OnPlayerResetEvent != null)
            {
                OnPlayerResetEvent.OnEventRaised -= OnPlayerReset;
            }
            if (OnPlayerGameResetEvent != null)
            {
                OnPlayerGameResetEvent.OnEventRaised -= OnPlayerGameReset;
            }
            if (OnPlayerHealthPowerupEvent != null)
            {
                OnPlayerHealthPowerupEvent.OnEventRaised -= OnPlayerHealthPowerup;
            }
            if (OnPlayerOneUpPowerupEvent != null)
            {
                OnPlayerOneUpPowerupEvent.OnEventRaised -= OnPlayerOneUpPowerup;
            }
            if (OnEntityHitEvent != null)
            {
                OnEntityHitEvent.OnEventRaised -= OnPlayerEntityHit;
            }
            if (OnEntityDeathEvent != null)
            {
                OnEntityDeathEvent.OnEventRaised -= OnEntityDeath;
            }
            if (PlayerLivesChannel != null)
            {
                PlayerLivesChannel.OnEventRaised -= OnPlayerLivesChange;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            if (!isShielded)
            {
                int initialHealth = CurrentHealth.Value;
                base.TakeDamage(damage);
                OnPlayerHitEvent?.RaiseEvent(damage);
                OnPlayerHealthEvent?.RaiseEvent(initialHealth, CurrentHealth.Value, MaxHealth.Value);
            }
        }

        private void AddHealth(int bonus)
        {
            int initialHealth = CurrentHealth.Value;
            int clampedHealth = Mathf.Clamp(CurrentHealth.Value + bonus, 0, Int32.MaxValue);
            CurrentHealth.SetValue(clampedHealth);
            OnPlayerHealthEvent?.RaiseEvent(initialHealth, CurrentHealth.Value, MaxHealth.Value);
        }

        public void ResetLives()
        {
            PlayerLivesChannel.SetValue(MaxPlayerLives);
        }

        private void AddLife()
        {
            PlayerLivesChannel.SetValue(PlayerLivesChannel.Value + 1);
        }

        /// <summary>
        /// Catches the event when a player's shields go up.
        /// </summary>
        /// <param name="eventType"></param>
        public void OnShieldsUp()
        {
            isShielded = true;
        }

        /// <summary>
        /// Catches the event when a player's shields go down.
        /// </summary>
        /// <param name="eventType"></param>
        public void OnShieldsDown()
        {
            isShielded = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        public void OnPlayerDeath(GameObject otherGO)
        {
            if (otherGO.GetInstanceID() == gameObject.GetInstanceID())
            {
                PlayerLivesChannel.SetValue(PlayerLivesChannel.Value - 1);
            }
        }

        public void OnPlayerSpawn()
        {
            // ResetHealth();
        }

        public void OnPlayerEntityHit(GameObject otherGO, int damageAmount)
        {
            if (otherGO.GetInstanceID() == gameObject.GetInstanceID())
            {
                OnPlayerHitEvent?.RaiseEvent(damageAmount);
            }
        }

        public void OnEntityDeath(GameObject otherGO)
        {
            if (otherGO.GetInstanceID() == gameObject.GetInstanceID())
            {
                OnPlayerDeathEvent?.RaiseEvent(otherGO);
            }
        }

        public void OnPlayerLivesChange(int currentLives)
        {
            if (currentLives <= 0)
            {
                OnGameOverEvent?.RaiseEvent();
            }
            else
            {
                OnLevelRestartLastCheckpointEvent?.RaiseEvent();
            }
        }

        public void OnPlayerReset()
        {
            ResetHealth();
        }

        public void OnPlayerGameReset()
        {
            // throw new NotImplementedException();
        }

        public void OnPlayerHealthPowerup(int heathBonus)
        {
            AddHealth(heathBonus);
        }

        public void OnPlayerOneUpPowerup()
        {
            AddLife();
        }
    }

    // [CustomEditor(typeof(PlayerHealth))]
    // public class PlayerHealthEditor : Editor
    // {
    //     public override void OnInspectorGUI()
    //     {
    //         PlayerHealth health = (PlayerHealth)target;
    //         DrawDefaultInspector();
    //         if (GUILayout.Button("Reset Health"))
    //         {
    //             PlayerResetEvent.Trigger("Player Reset Event");
    //         }
    //         if (GUILayout.Button("Player Hit 10"))
    //         {
    //             GameObject newObject = new("New Object");
    //             OnEntityHitEvent.RaiseEvent(health.gameObject.GetInstanceID(),
    //                     newObject, 10);
    //             Destroy(newObject);
    //         }
    //         if (GUILayout.Button("Player Death"))
    //         {
    //             PlayerDeathEvent.Trigger("Test Player Death");
    //         }
    //     }
    // }
}

