using System;
using Systems;
using Systems.Abilities;
using UnityEngine;

namespace Ships.DataManagement
{
    /// <summary>
    ///     Stores the data that is different between separate ship types (ex. base stats and visuals).
    ///     Also stores a unique ID associated with the ship type to use for saving and loading.
    /// </summary>
    [CreateAssetMenu(fileName = "Ships", menuName = "Ships/ShipData")]
    [Serializable]
    public class ShipData : UniqueId
    {
        [Header("Info")]
        [SerializeField] private string displayName;
        [SerializeField] private GameObject visuals;
        [SerializeField] private Sprite shopIcon;
        [SerializeField] private int cost;
        [SerializeField] private bool blocksMovement = true;
        [SerializeField] private AbilityData abilityData;

        [Header("Base Stats")]
        [SerializeField] private float health = 10;
        [SerializeField] private float speedMultiplier = 1;
        [SerializeField] private float damageMultiplier = 1;
        [SerializeField] private float sensorRange = 50;

        [Header("Config")]
        [SerializeField] private float targetRange;
        [SerializeField] private float buyCooldown;
        [SerializeField] private float rotateRange;
        [SerializeField] private float rotateSpeed;
        public float BaseHealth => health;
        public float BaseSpeedMultiplier => speedMultiplier;
        public float BaseDamageMultiplier => damageMultiplier;
        public float TargetRange => targetRange;
        public bool BlocksMovement => blocksMovement;
        public AbilityData AbilityData => abilityData;
        public float SensorRange => sensorRange;
        public string DisplayName => displayName;
        public GameObject Visuals => visuals;
        public Sprite ShopIcon => shopIcon;
        public int Cost => cost;
        public float BuyCooldown => buyCooldown;
        public float RotateRange => rotateRange;
        public float RotateSpeed => rotateSpeed;
    }
}
