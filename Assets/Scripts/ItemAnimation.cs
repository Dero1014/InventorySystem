using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    public float RotationAnimation;
    public float SpeedAnimation;

    public float BouncyDistance;

    private int _bouncyDirection;

    private Transform _parent;

    private void Start()
    {
        _parent = transform.parent;
        _bouncyDirection = 1;
    }

    private void Update()
    {

        transform.Rotate(0, 1 * RotationAnimation * Time.deltaTime, 0);
        transform.position += Vector3.up * SpeedAnimation * _bouncyDirection * Time.deltaTime;

        if(Mathf.Abs(transform.localPosition.y) >= BouncyDistance)
        {
            _bouncyDirection *= -1;
        }
        
    }

}
