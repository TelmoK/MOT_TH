using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ReboundComponent : MonoBehaviour
{
    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BulletMovement>() != null)
        {
            Vector3 oldDirection = collision.gameObject.GetComponent<BulletMovement>().Speed;
            Vector3 normal = collision.GetContact(0).normal;
            // Por el método del paralelogramo:
            Vector3 newDirection = (oldDirection - 2 * (Vector3.Dot(oldDirection, normal) * normal)).normalized;
            collision.gameObject.GetComponent<BulletMovement>().SetDirection(newDirection);
        }
    }
    #endregion
}
