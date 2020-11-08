using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireComponent : MonoBehaviour
{
    

    public void Fire()
    {
        ProjectileSpawnerComponent projectileSpawner = gameObject.GetComponentInChildren<ProjectileSpawnerComponent>();

        if (!projectileSpawner) return;
        projectileSpawner.SpawnProjectile();
    }
}
