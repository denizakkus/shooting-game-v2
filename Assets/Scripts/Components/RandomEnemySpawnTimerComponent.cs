using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawnTimerComponent : MonoBehaviour
{
    [SerializeField] private UnityEngine.Events.UnityEvent timeUpListener;
    [SerializeField] private float maxWaitingTime = 5;
    [SerializeField] private float minWaitingTime = 2;

    private float randomTime;

    // Start is called before the first frame update
    void Start()
    {
        randomTime = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (randomTime >= maxWaitingTime)
        {
            randomTime = GetRandomTime();

            // callback to enemyspawncomponent
            timeUpListener?.Invoke();
        }
        randomTime += Time.deltaTime;
    }

    private float GetRandomTime()
    {
        return Random.Range(minWaitingTime, maxWaitingTime);
    }


}
