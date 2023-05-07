using System.Collections.Generic;

using Ships.Fleets;
using Systems.Modifiers;
using UnityEngine;

namespace Systems.Abilities
{
    /// <summary>
    ///     Data for an ability that can be activated to apply modifiers to a target, with a set cooldown
    ///     between activations.
    /// </summary>
    [CreateAssetMenu(fileName = "New Ability", menuName = "Abilities/Ability", order = 0)]
    public class AbilityData : UniqueId
    {
        [Header("Info")] [SerializeField] private GameObject visuals;
        [SerializeField] private string attackName;
        [SerializeField] private int cost;
        [SerializeField] private List<ModifierData> modifiers;
        [SerializeField] private int cooldown;
        //[SerializeField] private ButtonData buttonData;
        [SerializeField] private FleetAgroStatus validTargets;
        [SerializeField] private List<string> tags;
        [SerializeField] private string fireSound;
        [SerializeField] private string hitSound;

        [Header("Projectile Stats")] 
        
        [SerializeField] private int damage;
        [SerializeField] private float speed;

        public List<ModifierData> Modifiers => modifiers;
        public int Cooldown => cooldown;
        //public ButtonData ButtonData => buttonData;
        public FleetAgroStatus ValidTargets => validTargets;
        public List<string> Tags => tags;
        public string FireSound => fireSound;
        public string HitSound => hitSound;
        public GameObject Visuals => visuals;
        public string AttackName => attackName;
        public int Cost => cost;
        public float BaseDamage => damage;
    }
}