using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeComponent : MonoBehaviour
{
    [SerializeField] private float maxLifeTime = 5;
    [SerializeField] private bool shouldResetLifeTime;
    private float lifeTime;

    PoolableComponent poolableComponent;

    private void OnEnable()
    {
        if (shouldResetLifeTime) lifeTime = 0;
    }

    private void Awake()
    {
        poolableComponent = gameObject.GetComponent<PoolableComponent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime >= maxLifeTime)
        {
            poolableComponent.AddToPool();
        }
        lifeTime += Time.deltaTime;
    }
}
