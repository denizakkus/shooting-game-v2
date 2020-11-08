using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    private Queue<GameObject> inventory;

    private int inventoryCounter;
    private int inventoryLimit;

    private void Awake()
    {
        inventory = new Queue<GameObject>();
    }

    public void AddToInventory(GameObject obj)
    {
        obj.SetActive(false);
        inventory.Enqueue(obj);
        inventoryCounter += 1;
    }

    public GameObject GetItemFromInventory()
    {
        if (inventoryCounter == 0) return null;

        GameObject obj = inventory.Dequeue();
        obj.SetActive(true);

        inventoryCounter -= 1;
        return obj;
    }
}
