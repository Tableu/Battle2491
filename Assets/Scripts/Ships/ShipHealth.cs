using System;
using Newtonsoft.Json.Linq;
using Systems.Save;
using UnityEngine;

namespace Ships.Components
{
    /// <summary>
    ///     Stores ship health and manages receiving damage.
    /// </summary>
    public class ShipHealth : MonoBehaviour,ISavable
    {
        private bool _healthDirty;

        private float _maxHealth;
        private GameObject _visuals;

        protected ShipStats Stats;


        public ShipStats ShipStats => Stats;
        public float Health => PercentHealth * _maxHealth;
        public float PercentHealth { get; protected set; } = 1f;
        public GameObject Visuals => _visuals;

        public void SetData(float maxHealth, GameObject visuals)
        {
            _maxHealth = maxHealth;
            _visuals = visuals;
        }
        private void Awake()
        {
            Stats = GetComponent<ShipStats>();
        }
        private void Update()
        {
            if (_healthDirty)
            {
                _healthDirty = false;
                OnHealthChanged?.Invoke();
            }
        }

        public void TakeDamage(float damage)
        {
            PercentHealth -= damage / _maxHealth;
            PercentHealth = Mathf.Min(PercentHealth, 1);
            _healthDirty = true;
            if (Health <= 0.01)
            {
                OnDestroyed?.Invoke();
            }
        }

#if UNITY_EDITOR
        [ContextMenu("Test Damage")]
        public void TestDamage()
        {
            TakeDamage(10);
        }
#endif
        [ContextMenu("Repair")]
        public void Repair()
        {
            PercentHealth = 1;
            OnHealthChanged?.Invoke();
        }

        
        public event Action OnHealthChanged;
        public event Action OnDestroyed;
        
        public void Start()
        {
            OnDestroyed += delegate
            {
                //TODO handle other parts of death
                Destroy(gameObject); //Kill ship
            };
        }

        public string id => "health";

        public object SaveState()
        {
            return new SaveData
            {
                CurrentHealth = PercentHealth
            };
        }

        public void LoadState(JObject state)
        {
            var saveData = state.ToObject<SaveData>();
            PercentHealth = saveData.CurrentHealth;
        }

        [Serializable]
        private struct SaveData
        {
            public float CurrentHealth;
        }
    }
}