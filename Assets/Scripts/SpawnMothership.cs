using Ships.DataManagement;
using Ships.Fleets;
using UnityEngine;

public class SpawnMothership : MonoBehaviour
{
    [SerializeField] private FleetManager mothershipManager;
    [SerializeField] private LineRenderer mothershipPath;
    [SerializeField] private ShipData mothershipData;
    // Start is called before the first frame update
    void Start()
    {
        var mothership = mothershipManager.SpawnShip(mothershipData, mothershipPath.GetPosition(0));
        var line = mothership.GetComponent<FollowLine>();
        if (line != null)
        {
            line.Line = mothershipPath;
            line.Speed = mothershipData.BaseSpeedMultiplier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
