using System;
using Ships.DataManagement;
using Ships.Fleets;
using Systems.Modifiers;
using UnityEngine;

namespace Ships.Components
{
    /// <summary>
    ///     Stores basic ship information, such as stats and data.
    /// </summary>
    public class ShipStats : ModifiableTarget
    {
        private GameObject _visuals;
        [SerializeField] private ShipData data;
        public ShipData Data => data;
        public GameObject Visuals => _visuals;
        private TargetingHelper _targetingHelper;
        public FleetManager Fleet { get; private set; }

        // ModifiableStat must be read only so that other components can get references to them during Start/Awake.
        public ModifiableStat MaxHealth { get; } = new ModifiableStat(0);
        public ModifiableStat DamageMultiplier { get; } = new ModifiableStat(0);
        public ModifiableStat SpeedMultiplier { get; } = new ModifiableStat(0);
        public ModifiableStat SensorRange{ get; } = new ModifiableStat(0);
        public TargetingHelper TargetingHelper => _targetingHelper;

        private void Awake()
        {
            if (data != null)
            {
                Initialize();
            }
        }

        private void OnDestroy()
        {
            OnShipDestroyed?.Invoke();
        }


        /// <summary>
        ///     Used to initialize the data field when a ship is instantiated at runtime.
        ///     Must be called immediately after instantiation if the data field is not set in the inspector.
        /// </summary>
        /// <param name="shipData">The data to initialize the ship with</param>
        public void Initialize(ShipData shipData)
        {
            // This function is not expected to be called multiple times or if ship data is provided via the inspector
            Debug.Assert(data == null, "ShipStats.data overwritten");
            data = shipData;
            Initialize();
        }

        /// <summary>
        ///     Performs internal initialization, must be called on or before first frame.
        /// </summary>
        private void Initialize()
        {
            var parent = transform.parent;
            Debug.Assert(parent != null, "transform.parent != null");
            Fleet = parent.GetComponent<FleetManager>();
            Debug.Assert(Fleet != null, "Ship Parent must contain fleet manager");
            // Set all the base values
            MaxHealth.UpdateBaseValue(data.BaseHealth);
            DamageMultiplier.UpdateBaseValue(data.BaseDamageMultiplier);
            SpeedMultiplier.UpdateBaseValue(data.BaseSpeedMultiplier);
            SensorRange.UpdateBaseValue(data.SensorRange);

            // Add ship visuals
            //todo rework this to handle spawning
            //_visuals = Instantiate(data.Visuals, ShipVisualsManager.Instance.GetParent());
            //_visuals.transform.position = ShipVisualsManager.Instance.GetPosition();
            
            //Init hull
            ShipHealth shipHealth = gameObject.AddComponent<ShipHealth>();
            shipHealth.SetData(data.BaseHealth, _visuals);
            
            _targetingHelper = gameObject.AddComponent<TargetingHelper>();
            _targetingHelper.Initialize(data, this);
        }

        public event Action OnShipDestroyed;
    }
}
