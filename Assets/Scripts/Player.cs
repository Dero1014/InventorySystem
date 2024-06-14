using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _gravity;

    private InventoryHolder _playerInventory;
    private Rigidbody _rb;

    private Vector3 _direction;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerInventory = GetComponent<InventoryHolder>();
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
            if (_playerInventory.InventorySystem.AddItemToInventory(collision.gameObject.GetComponent<ItemObject>().ItemData))
            {
                collision.gameObject.SetActive(false);
            }
        }
    }

}
