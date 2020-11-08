using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EquippableMap")]
[System.Serializable]
public class EquippableMap : ScriptableObject
{
    [System.Serializable]
    public struct EquippableTuple
    {
        public GameObject prefab;
        public EquippableTypes EquippableType;
    }

    [SerializeField] public List<EquippableTuple> equippableTuples;
}
