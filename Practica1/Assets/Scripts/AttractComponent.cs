using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttractComponent : MonoBehaviour
{
    #region parameters
    [SerializeField] private float _attraction;
    #endregion

    #region references
    private Transform _myTransform;
    #endregion

    #region methods
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletMovement>() != null)
        {
            Vector3 _bulletPosition = collision.transform.position;
            Vector3 _areaPosition = _myTransform.position;
            Vector3 attDirection = _areaPosition - _bulletPosition;
            collision.GetComponent<BulletMovement>().AddSpeed(attDirection.normalized * _attraction);
        }
    }
    #endregion

    void Start()
    {
        _myTransform = transform;
    }
}
