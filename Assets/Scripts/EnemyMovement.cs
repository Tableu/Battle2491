using Ships.Components;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _mothership;

    private ShipStats _shipStats;
    // Start is called before the first frame update
    void Start()
    {
        _shipStats = GetComponent<ShipStats>();
        _mothership = GlobalReferences.Instance.Mothership;
    }

    // Update is called once per frame
    void Update()
    {
        if (_mothership != null && _mothership.transform != null && Vector2.Distance(transform.position,_mothership.transform.position) > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, _mothership.transform.position,_shipStats.Data.BaseSpeedMultiplier);
            transform.LookAt(_mothership.transform.position);
            transform.right = _mothership.transform.position - transform.position;
        }
    }
}
