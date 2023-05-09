using Ships.Components;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _mothership;

    private ShipStats _shipStats;
    private bool _reachedTarget;
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
            if (!_reachedTarget && Vector2.Distance(transform.position, _mothership.transform.position) < _shipStats.Data.RotateRange)
            {
                _reachedTarget = true;
            }

            if (_reachedTarget)
            {
                transform.RotateAround(_mothership.transform.position, new Vector3(0,0,1),_shipStats.Data.RotateSpeed*Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, _mothership.transform.position,
                    _shipStats.Data.BaseSpeedMultiplier);
            }
            transform.LookAt(_mothership.transform.position);
            transform.right = _mothership.transform.position - transform.position;
        }
    }
}
