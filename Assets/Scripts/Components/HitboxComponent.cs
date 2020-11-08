using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class HitboxComponent : MonoBehaviour
{

    HealthComponent healthComponent;

    private void Awake()
    {
        healthComponent = gameObject.GetComponent<HealthComponent>();
        if (!healthComponent)
        {
            Debug.LogError("Hitbox & Health Components should exist together!");
            return;
        }
    }

    public void DealDamage(float damage)
    {
        healthComponent.HealthDown(damage);
    }
}
