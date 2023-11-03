using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class TargetComponent : MonoBehaviour
{
    #region references
    private GameManager _gameManager;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletMovement>() != null) _gameManager.OnTargetReached();
    }
    #endregion

    void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }
}
