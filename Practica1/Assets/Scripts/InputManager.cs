using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    #region references
    [SerializeField] private LookAtPositionComponent _playerLookAt;
    [SerializeField] private ShootingComponent _playerShooting;
    #endregion

    void Update()
    {
        _playerLookAt.SetLookAtPosition(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) _playerShooting.Shoot();
    }
}
