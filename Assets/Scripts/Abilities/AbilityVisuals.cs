using Ships.Components;
using Systems.Abilities;
using UnityEngine;

public class AbilityVisuals : MonoBehaviour
{
    private ShipStats _target;
    private AbilityData _abilityData;
    public void Initialize(AbilityData abilityData, ShipStats target, int layer)
    {
        _target = target;
        _abilityData = abilityData;
        gameObject.layer = layer;
        if (_target != null && _target.gameObject != null && _target.transform != null)
        {
            transform.LookAt(_target.transform.position);
            transform.right = _target.transform.position - transform.position;
        }
    }

    public void FixedUpdate()
    {
        if (_target == null || _target.gameObject == null || _target.transform == null)
        {
            Destroy(gameObject);
            return;
        }

        var pos = _target.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, pos,_abilityData.BaseSpeed);
        transform.LookAt(_target.transform.position);
        transform.right = _target.transform.position - transform.position;
        if (Vector2.Distance(transform.position,_target.transform.position) <= 0)
        {
            var health = _target.GetComponent<ShipHealth>();
            //Debug.Log(LayerMask.LayerToName(gameObject.layer) + '-'+_target.name);
            if (health != null)
            {
                health.TakeDamage(_abilityData.BaseDamage);
            }
            Destroy(gameObject);
        }
    }
}