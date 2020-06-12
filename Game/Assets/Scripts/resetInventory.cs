using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetInventory : MonoBehaviour
{
    Inventory inventory;
    InventorySlot[] slots;
    GameObject GameManager;

    void Start()
    {
        inventory = Inventory.instance;
        Destroy(inventory);
        GameManager = GameObject.Find("GameManager");
        GameManager.AddComponent<Inventory>();
    }
}
