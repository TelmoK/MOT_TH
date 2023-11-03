using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootingComponent : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _bulletPrefab;
    private Transform _myTransform;
    #endregion

    #region methods
    public void Shoot()
    {
        GameObject _newBullet = Instantiate(_bulletPrefab, _myTransform.position, _myTransform.rotation);
        _newBullet.GetComponent<BulletMovement>().Setup(_myTransform.right);
    }
    #endregion

    void Start()
    {
        _myTransform = transform;
    }
}
