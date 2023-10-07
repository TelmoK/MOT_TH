using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPositionComponent : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    #endregion

    #region properties
    private Vector3 _lookAtPosition;
    #endregion

    #region methods
    public void SetLookAtPosition(Vector3 mousePosition)
    {
        _lookAtPosition = mousePosition - Camera.main.WorldToScreenPoint(_myTransform.position);
    }
    #endregion

    void Start()
    {
        _myTransform = transform;
    }

    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(_lookAtPosition - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
