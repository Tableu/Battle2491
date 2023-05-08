using System.Collections;
using System.Collections.Generic;
using Ships.Components;
using Ships.DataManagement;
using Systems.Abilities;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    private AbilityData _abilityData;
    private TargetingHelper _targetingHelper;
    private bool _fire;
    private int _cooldown;
    
    void Start()
    {
        ShipStats shipStats = GetComponent<ShipStats>();
        _abilityData = shipStats.Data.AbilityData;
        _targetingHelper = shipStats.TargetingHelper;
        _cooldown = 0;
        _targetingHelper.OnTargetChanged += delegate
        {
            _fire = _targetingHelper.Target != null;
            if (!_fire)
            {
                _cooldown = 0;
            }
        };
    }

    void FixedUpdate()
    {
        if (_fire)
        {
            if (_cooldown > _abilityData.Cooldown)
            {
                var projectile = Instantiate(_abilityData.Visuals, GlobalReferences.Instance.ProjectileParent.transform);
                projectile.transform.position = transform.position;
                projectile.GetComponent<AbilityVisuals>()?.Initialize(_abilityData, _targetingHelper.Target, gameObject.layer);
                _cooldown = 0;
            }
            else
            {
                _cooldown++;
            }
        }
    }
}
