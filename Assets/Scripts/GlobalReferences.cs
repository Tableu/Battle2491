using System;
using UnityEngine;

public class GlobalReferences : MonoBehaviour
{
    private static GlobalReferences _instance;

    public static GlobalReferences Instance => _instance;
    
    [Header("References")]
    [SerializeField] private GameObject canvas;

    public GameObject Canvas => canvas;

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