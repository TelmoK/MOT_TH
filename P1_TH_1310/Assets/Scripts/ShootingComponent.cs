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
        //****** Instantiate clode of bullet prefab
        GameObject _newBullet = GameObject.Instantiate(_bulletPrefab, transform.position, transform.rotation);

        //****** Set proper direction according to player's rotation
        //*Hugo* transform.right es del propio cañón y ya es normalizada
        //_newBullet.GetComponent<BulletMovement>().SetDirection(transform.right);

        //*Hugo* Creo que aquí en Shoot() sea llamada la función Setup() y no la SetDirection()
        //*Hugo* La SetDirection() es llamada sólo por las paredes que rebotan
        _newBullet.GetComponent<BulletMovement>().Setup(transform.right);
    }
    #endregion
    void Start()
    {
        _myTransform = transform;
    }
}

