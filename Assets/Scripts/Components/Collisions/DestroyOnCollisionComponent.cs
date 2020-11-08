using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionComponent : MonoBehaviour
{
    private PoolableComponent poolableComponent;

    private void Awake()
    {
        poolableComponent = gameObject.GetComponent<PoolableComponent>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (poolableComponent)
        {
            poolableComponent.AddToPool();
        }
        else
        {
            Debug.Log($"{this.gameObject.name} is not a poolable object. -[DestroyComponent]");
            Destroy(this.gameObject);
        }
    }
}
