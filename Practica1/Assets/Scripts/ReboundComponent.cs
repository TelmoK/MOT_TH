using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ReboundComponent : MonoBehaviour
{
    #region methods
    /// <summary>
    /// This method detects if the collided object is a bullet. Use duck typing!
    /// If it is a bullet, the movement direction is set to fake a rebound on the surface:
    /// Normal, tangent, dot product and cross product will be required to accomplish this
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BulletMovement>() != null)
        {
            
            Vector3 oldDirection = collision.gameObject.GetComponent<BulletMovement>().Speed;
            Debug.Log(collision.GetContact(0).normal);
        }
        
    }
    #endregion
}
