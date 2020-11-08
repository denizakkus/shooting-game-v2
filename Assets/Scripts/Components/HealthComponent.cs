using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private UnityEngine.Events.UnityEvent onHealthUnderZero;
    [SerializeField] private float maxHealth;
    private float health;

    private void Awake()
    {
        health = maxHealth;
    }

    public void HealthUp(float damage)
    {
        if (health + damage > maxHealth) health = maxHealth;
        else health += damage;
    }
    
    public void HealthDown(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            onHealthUnderZero?.Invoke();
        }
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }
}
