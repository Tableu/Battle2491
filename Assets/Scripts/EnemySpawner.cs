using System;
using Ships.Fleets;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private CircleCollider2D detectionCollider;
    [SerializeField] private FleetManager enemyManager;
    [SerializeField] private RandomFleet randomFleet;

    [SerializeField] private int tick;
    
    private int _counter = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(GlobalReferences.Instance.Mothership))
        {
            foreach (RandomShipList ship in randomFleet.randomFleet)
            {
                GameObject enemy = enemyManager.SpawnShip(ship.RandomShip(),
                    transform.position + (Vector3) ship.SpawnPosition);
                enemy.layer = gameObject.layer;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.Equals(GlobalReferences.Instance.Mothership))
        {
            if (_counter < tick)
            {
                _counter++;
                return;
            }

            foreach (RandomShipList ship in randomFleet.randomFleet)
            {
                GameObject enemy = enemyManager.SpawnShip(ship.RandomShip(),
                    transform.position + (Vector3) ship.SpawnPosition);
                enemy.layer = gameObject.layer;
            }

            _counter = 0;
        }
    }
}
