using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxComponent : MonoBehaviour
{
    [SerializeField] private float damage = 10;
    HitboxComponent collisionHitboxComponent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionHitboxComponent = collision.collider.gameObject.GetComponent<HitboxComponent>();

        if (!collisionHitboxComponent) return;
        collisionHitboxComponent.DealDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        collisionHitboxComponent = collider.gameObject.GetComponent<HitboxComponent>();

        if (!collisionHitboxComponent) return;
        collisionHitboxComponent.DealDamage(damage);
    }
}
