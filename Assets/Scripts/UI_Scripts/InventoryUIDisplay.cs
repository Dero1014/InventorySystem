using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUIDisplay : MonoBehaviour
{
    public InventoryHolder InventoryHolder;
    [SerializeField]
    private InventorySystem _inventorySystem;
    [SerializeField]
    private InventoryUISlot[] _inventoryUISlots;
    public InventoryUISlot[] InventoryUISlots => _inventoryUISlots;

    void Start()
    {
        _inventoryUISlots = GetComponentsInChildren<InventoryUISlot>();
        _inventorySystem = InventoryHolder.InventorySystem;

        InitilizeDisplay();
    }

    void InitilizeDisplay()
    {
        for (int i = 0; i < _inventoryUISlots.Length; i++)
        {
            _inventoryUISlots[i].AssignSlotToUI(_inventorySystem.InventorySlots[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
