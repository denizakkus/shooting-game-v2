using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EquipperComponent))]
[RequireComponent(typeof(InventoryComponent))]
public class EquipHandlerComponent : MonoBehaviour
{
    EquipperComponent equipperComponent;
    InventoryComponent inventoryComponent;

    [SerializeField] private float radius = 0.6f;


    private void Awake()
    {
        equipperComponent = gameObject.GetComponent<EquipperComponent>();
        inventoryComponent = gameObject.GetComponent<InventoryComponent>();
    }

    public void Equip()
    {
        GameObject obj = SearchEquippableObjectInRadius();
        if (!obj) return;

        if (!equipperComponent.GetEquippedItem()) equipperComponent.SetEquippedItem(obj);
        else inventoryComponent.AddToInventory(obj);
    }

    public void SwtichItemFromInventory()
    {
        GameObject inventoryItem = inventoryComponent.GetItemFromInventory();

        if (!inventoryItem) return;

        GameObject equippedItem = equipperComponent.GetEquippedItem();

        if (!equippedItem) equipperComponent.SetEquippedItem(inventoryItem);
        else
        {
            equippedItem.gameObject.layer = LayerMask.NameToLayer("Item");
            inventoryComponent.AddToInventory(equippedItem);
            equipperComponent.SetEquippedItem(inventoryItem);
        }
    }

    public GameObject SearchEquippableObjectInRadius()
    {
        Collider2D collider = Physics2D.OverlapCircle(
            transform.position,
            radius,
            1 << LayerMask.NameToLayer("Item")
            );
        if (collider && collider.gameObject.GetComponent<EquippableComponent>()) return collider.gameObject;
        else return null;
    }
}
