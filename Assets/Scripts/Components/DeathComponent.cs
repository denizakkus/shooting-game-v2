using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    [SerializeField] UnityEngine.Events.UnityEvent onDeath;

    public void OnDeath()
    {
        onDeath?.Invoke();
    }
}
