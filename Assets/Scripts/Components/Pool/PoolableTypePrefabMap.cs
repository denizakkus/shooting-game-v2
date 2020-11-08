using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PoolableTypePrefabMap")]
[System.Serializable]
public class PoolableTypePrefabMap : ScriptableObject
{
    [System.Serializable]
    public struct PoolableTypePrefabTuple
    {
        public GameObject prefab;
        public PoolableTypes poolableType;
    }

    [SerializeField] public List<PoolableTypePrefabTuple> poolableTypePrefabTuples;
}
