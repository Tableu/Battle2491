using System;
using System.Collections.Generic;
using Ships.DataManagement;
using Ships.Fleets;
using Systems.Abilities;
using UnityEngine;

namespace Ships.Components
{
    /// <summary>
    ///     Stores references to ship target and contains helper functions/events related to targeting
    /// </summary>
    /// todo add targeting priorities
    public class TargetingHelper : MonoBehaviour
    {
        private ShipStats _shipStats;
        private ShipData _data;
        private ShipStats _target;
        private List<ShipStats> _targets;
        public ShipStats Target => _target;

        public void Initialize(ShipData shipData, ShipStats shipStats)
        {
            // This function is not expected to be called multiple times or if ship data is provided via the inspector
            Debug.Assert(_data == null, "TargetingHelper.data overwritten");
            _shipStats = shipStats;
            _data = shipData;
            _targets = new List<ShipStats>();
        }

        public void SetTarget(ShipStats target)
        {
            if (target == null)
            {
                _target = target;
                OnTargetChanged?.Invoke();
            }
        }

        public bool IsEnemy(ShipStats target)
        {
            _shipStats.Fleet.AgroStatusMap.TryGetValue(target.Fleet, out FleetAgroStatus fleetAgroStatus);
            return fleetAgroStatus == FleetAgroStatus.Hostile || fleetAgroStatus == FleetAgroStatus.Neutral;
        }

        public bool InRange()
        {
            if (_target != null &&
                (_shipStats.transform.position - _target.transform.position).magnitude < _shipStats.SensorRange)
            {
                return true;
            }

            return false;
        }

        public event Action OnTargetChanged;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var target = other.GetComponent<ShipStats>();
            if (target != null)
            {
                _targets.Add(target);
                _target = target;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var target = other.GetComponent<ShipStats>();
            if (target != null)
            {
                _targets.Remove(target);
            }
        }
    }
}