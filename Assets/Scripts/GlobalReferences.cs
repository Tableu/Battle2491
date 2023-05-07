using System;
using Ships.Fleets;
using UnityEngine;

public class GlobalReferences : MonoBehaviour
{
    private static GlobalReferences _instance;

    public static GlobalReferences Instance => _instance;
    
    [Header("References")]
    [SerializeField] private GameObject canvas;

    [SerializeField] private FleetManager turretManager;
    [SerializeField] private GameObject fogOfWarCanvas;

    public GameObject Canvas => canvas;
    public GameObject FogOfWarCanvas => fogOfWarCanvas;

    public FleetManager TurretManager => turretManager;

    public PlayerInputActions PlayerInputActions
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        PlayerInputActions = new PlayerInputActions();
        PlayerInputActions.Enable();
    }
}
