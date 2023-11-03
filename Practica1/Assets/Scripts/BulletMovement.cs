using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletMovement : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _speedValue = 1.0f;
    #endregion

    #region references
    private Transform _myTransform;
    #endregion

    #region properties
    private Vector3 _speed;
    public Vector3 Speed
    {
        get { return _speed; }
    }
    #endregion

    #region methods
    public void SetDirection(Vector3 newDirection)
    {
        _speed = newDirection * _speedValue;
    }
    public void AddSpeed(Vector3 speedToAdd)
    {
        _speed += speedToAdd;
    }
    public void Setup(Vector2 direction)
    {
        _speed = direction * _speedValue;
    }
    #endregion

    void Start()
    {
        _myTransform = transform;
    }

    void Update()
    {
        _myTransform.position += _speed * Time.deltaTime;
    }
}
