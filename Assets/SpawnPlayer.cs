using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab;

    public static GameObject spawnedObject;

    // Start is called before the first frame update
    void Awake()
    {
        spawnedObject = Instantiate(playerPrefab);
    }
}
