using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    private float _speedValue = 1.0f;
    private Transform _myTransform;
    private Vector3 _speed;
    public Vector3 Speed
    {
        get { return _speed; }
    }

    public void SetDirection(Vector3 newDirection)
    {
        //*Hugo* El vector newDirection ya viene normalizado => transform.right o transform.forward de la pared
        _speed = newDirection * _speedValue;
    }

    public void AddSpeed(Vector3 speedToAdd)
    {
        _speed += speedToAdd;
        _speed.Normalize();
        _speed *= _speedValue;
    }
    public void Setup(Vector2 direction)
    {
        //*Hugo* El vector direction ya viene normalizado => transform.right del cañón
        _speed = direction * _speedValue;
    }

    void Start()
    {
        _myTransform = transform;
    }

    void Update()
    {
        _myTransform.position += _speed * Time.deltaTime;
    }
}

