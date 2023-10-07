using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetComponent : MonoBehaviour
{
    #region references
    private GameManager _gameManager;
    #endregion
    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("EEEEEYYYYY " + collision.GetInstanceID());

    }
    #endregion
    void Start()
    {
        
    }
}
