using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    public int InventorySize;

    [SerializeField]
    private InventorySystem _inventorySystem;
    public InventorySystem InventorySystem => _inventorySystem;

    void Start()
    {
        _inventorySystem = new InventorySystem();
        for (int i = 0; i < InventorySize; i++)
        {
            _inventorySystem.InitSlot();
        }
    }

}
