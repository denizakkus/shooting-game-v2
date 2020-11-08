using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerComponent : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnerTransform;
    [SerializeField] private float bulletVelocityMagnitude;

    public void SpawnProjectile()
    {
        if (!bulletPrefab)
        {
            Debug.LogError("Bullet prefab was not found.");
            return;
        }

        PoolableComponent poolableComponent = bulletPrefab.gameObject.GetComponent<PoolableComponent>();

        GameObject obj;
        if (poolableComponent)
        {
            obj = PoolManager.Instance.GetFromPool(poolableComponent.GetPoolableType());
        }
        else
        {
            obj = Instantiate(bulletPrefab);
        }

        // WARNING
        // BU COMPONENTIN TEK ISI, PROJECTILE SPAWNLAMAK!
        // ONU AYARLAMAK DEGIL, SIMDILIK BURAYA YAPIYORUM.
        HandleProjectile(obj);
    }

    // WARNING
    // BU COMPONENTIN TEK ISI, PROJECTILE SPAWNLAMAK!
    // ONU AYARLAMAK DEGIL, SIMDILIK BURAYA YAPIYORUM.

    private void HandleProjectile(GameObject obj)
    {
        SetProjectilePosition(obj);
        SetProjectileUp(obj);
        SetProjectileVelocity(obj);
    }

    private void SetProjectilePosition(GameObject obj)
    {
        obj.transform.position = spawnerTransform.position;
    }

    private void SetProjectileUp(GameObject obj)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 destination = new Vector2(
            position.x,
            position.y
            );

        Vector2 finalDestination = new Vector2(
            (destination.x - spawnerTransform.position.x),
            (destination.y - spawnerTransform.position.y)
            );

        obj.transform.up = finalDestination;
    }

    private void SetProjectileVelocity(GameObject obj)
    {
        obj.GetComponent<Rigidbody2D>().velocity = obj.transform.up * bulletVelocityMagnitude;
    }
}
