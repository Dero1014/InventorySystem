using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField]
    private ItemData _itemData;
    private Material _material;

    public ItemData ItemData => _itemData;

    void Start()
    {
       _material = GetComponentInChildren<Renderer>().material;
        _material.color = _itemData.GetColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
