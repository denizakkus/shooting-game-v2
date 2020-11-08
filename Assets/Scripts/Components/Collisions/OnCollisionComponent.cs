using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionComponent : MonoBehaviour
{
    [SerializeField] private UnityEngine.Events.UnityEvent onCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onCollision?.Invoke();
    }
}
