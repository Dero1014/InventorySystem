using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int _inventorySize;
    [SerializeField] protected InventorySystem _inventorySystem;

    public InventorySystem InventorySystem => _inventorySystem;

    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequest;

    private void Awake()
    {
        _inventorySystem = new InventorySystem(_inventorySize);
    }

}
