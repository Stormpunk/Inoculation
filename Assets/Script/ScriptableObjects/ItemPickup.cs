using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemBase item;

    public void Use()
    {
        TestInventory.instance.AddToInventory(item.itemName);
        Debug.Log("Picked up + " +  item.itemName);
        GameManager.instance.ItemTextUpdate(item.itemDescription);
        Destroy(this.gameObject);
    }
}
