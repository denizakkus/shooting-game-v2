using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipperComponent : MonoBehaviour
{
    [SerializeField] private Transform equippableObjectHolder;
    private GameObject equippedItem;

    private void Awake()
    {
        equippedItem = null;
    }

    public void SetEquippedItem(GameObject obj)
    {
        if (equippedItem) equippedItem.transform.parent = null;
        equippedItem = obj;

        equippedItem.transform.up = equippableObjectHolder.up;
        equippedItem.transform.parent = equippableObjectHolder;
        equippedItem.transform.position = equippableObjectHolder.position;
        equippedItem.gameObject.layer = equippableObjectHolder.gameObject.layer;
    }
    public GameObject GetEquippedItem()
    {
        return equippedItem;
    }
}
