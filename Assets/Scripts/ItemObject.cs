using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [Range(0,1)]
    public float StackSizeModifier = 0.5f;

    [SerializeField] private InventoryItemData _itemData;
    [SerializeField] private int _stack = 1;

    private Material _material;

    public InventoryItemData ItemData=>_itemData;
    public int Stack => _stack;

    void Start()
    {
        _material = GetComponentInChildren<Renderer>().material;
        _material.color = _itemData.ItemColor;
        if (_stack > 1)
        {
            transform.GetChild(0).localScale = Vector3.one * _stack * StackSizeModifier;
        }
    }
}
