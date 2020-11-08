using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableComponent : MonoBehaviour
{
    [SerializeField] private PoolableTypes poolType;

    public void AddToPool()
    {
        PoolManager.Instance.AddToPool(this.gameObject, poolType);
    }

    public PoolableTypes GetPoolableType()
    {
        return poolType;
    }
}
