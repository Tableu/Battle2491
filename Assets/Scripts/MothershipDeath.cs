using System.Collections;
using System.Collections.Generic;
using Ships.Components;
using UnityEngine;

public class MothershipDeath : MonoBehaviour
{
    [SerializeField] private GameObject levelEndPopup;
    private ShipHealth _health;
    // Start is called before the first frame update
    void Start()
    {
        _health = GetComponent<ShipHealth>();
        _health.OnDestroyed += delegate
        {
            Time.timeScale = 0;
            var popup = Instantiate(levelEndPopup, GlobalReferences.Instance.Canvas.transform);
            popup.GetComponent<LevelEndPopup>().Initialize(LevelEndPopupType.Death);
        };
    }
}
