using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Loot,
    Consumable,
    Equipment
}

[CreateAssetMenu(menuName = "Inventory System/Item Data")]
public class ItemData : ScriptableObject
{
    public int ID;

    [SerializeField]
    private string _name;
    [SerializeField]
    private string _description;
    [SerializeField]
    private ItemType _itemType;

    [SerializeField]
    private int _maxStack = 1;

    [SerializeField]
    private Color _matColor;

    private Material _material;

    public int GetMaxStack()
    {
        return _maxStack;
    }

    public Color GetColor()
    {
        return _matColor;
    } 
    
}
