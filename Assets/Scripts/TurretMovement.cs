using System.Collections;
using System.Collections.Generic;
using Ships.Components;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    private ShipStats _shipStats;
    // Start is called before the first frame update
    void Start()
    {
        _shipStats = GetComponent<ShipStats>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.position, new Vector3(0,0,1),_shipStats.Data.RotateSpeed*Time.deltaTime);
    }
}
