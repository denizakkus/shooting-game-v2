using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnEnemyComponent : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;

    // TODO: v2 - SET ACCORDING TO ASPECT RATIO
    [SerializeField] private float randomEnemyCreationDifficultyBoundary;

    HealthComponent healthComponent;
    PoolableComponent poolableComponent;
    AutoMoveComponent autoMoveComponent;
    TurnFaceToDestinationComponent turnFaceComponent;

    private int xBoundary, yBoundary;
 

    private void Awake()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));

        if (randomEnemyCreationDifficultyBoundary > worldPosition.x ||
            randomEnemyCreationDifficultyBoundary > worldPosition.y)
        {
            Debug.LogError("BoundaryLimit is too high. ~SpawnEnemyComponent");
        }

        // CeilToInt returns smallest integer greater or equal than given float.
        xBoundary = Mathf.CeilToInt(worldPosition.x);
        yBoundary = Mathf.CeilToInt(worldPosition.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        poolableComponent = enemyPrefab.gameObject.GetComponent<PoolableComponent>();
    }

    private bool GetSpawnedObjectComponents(GameObject obj)
    {
        turnFaceComponent = obj.gameObject.GetComponent<TurnFaceToDestinationComponent>();
        autoMoveComponent = obj.gameObject.GetComponent<AutoMoveComponent>();
        healthComponent = obj.gameObject.GetComponent<HealthComponent>();

        if (turnFaceComponent && autoMoveComponent && healthComponent) return true;
        return false;
    }

    private void TurnFaceHandler()
    {
        turnFaceComponent.destination = SpawnPlayer.spawnedObject.transform;
        turnFaceComponent.SetShouldTrackMouse(false);
    }

    private void AutoMoveHandler()
    {

        autoMoveComponent.destinationTransform = SpawnPlayer.spawnedObject.transform;
        autoMoveComponent.shouldMoveToDestination = true;
    }

    private void HealthHandler()
    {
        healthComponent.ResetHealth();
    }

    private void PositionHandler(GameObject obj)
    {
        Vector2 randomPosition = CreateRandomPosition();
        obj.transform.position = new Vector2(randomPosition.x, randomPosition.y);
    }

    private Vector2 CreateRandomPosition()
    {
        int region = Random.Range(0, 4);
        Debug.Log(region);

        switch (region)
        {
            case 0:
                return new Vector2(
                    Random.Range(-xBoundary, xBoundary),
                    Random.Range((yBoundary - randomEnemyCreationDifficultyBoundary), yBoundary)
                    );
            case 1:
                return new Vector2(
                    Random.Range(xBoundary - randomEnemyCreationDifficultyBoundary, xBoundary),
                    Random.Range(-yBoundary, yBoundary)
                    );
            case 2:
                return new Vector2(
                    Random.Range(-xBoundary, xBoundary),
                    Random.Range((-yBoundary), (-yBoundary + randomEnemyCreationDifficultyBoundary))
                    );
            case 3:
                return new Vector2(
                    Random.Range((-xBoundary), (-xBoundary + randomEnemyCreationDifficultyBoundary)),
                    Random.Range(-yBoundary, yBoundary)
                    );
            default:
                Debug.Log("I SHOULD NOT ENTER HERE -Defalut");
                return Vector2.zero;
        }
    }

    private void SpawnedObjectHandler(GameObject obj)
    {
        obj.transform.position = Vector3.zero;

        HealthHandler();
        TurnFaceHandler();
        AutoMoveHandler();
        PositionHandler(obj);
    }


    public void SpawnEnemy()
    {
        if (enemyPrefab)
        {
            GameObject obj;
            if (poolableComponent)
            {
                obj = PoolManager.Instance.GetFromPool(poolableComponent.GetPoolableType());
            }
            else
            {
                Debug.Log("ENEMY PREFAB DOES NOT HAVE POOLABLE COMPONENT");
                return;
            }

            if (!GetSpawnedObjectComponents(obj)) return;
            SpawnedObjectHandler(obj);
        }
    }
}
