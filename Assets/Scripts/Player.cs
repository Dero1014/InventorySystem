using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _gravity;

    private Rigidbody _rb;

    private Vector3 _direction;

    private InventoryHolder _inventory;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _inventory = GetComponent<InventoryHolder>();
    }

    void Update()
    {
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        Move(_direction);
        Gravity();
    }

    void Gravity()
    {
        _rb.velocity += Vector3.down * _gravity;
    }

    void Move(Vector3 direction)
    {
        _rb.velocity = direction.normalized * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            var itemObj = collision.gameObject.GetComponentInParent<ItemObject>();
            if(_inventory.InventorySystem.AddToInventory(itemObj.ItemData, itemObj.Stack))
                itemObj.gameObject.SetActive(false);
        }
    }

}
