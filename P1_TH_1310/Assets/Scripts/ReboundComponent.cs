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
            //BulletMovement bullet_movement = collision.gameObject.GetComponent<BulletMovement>();
            //Vector3 oldDirection = bullet_movement.Speed;

            //bullet_movement.SetDirection(oldDirection);
            Debug.Log(collision.GetContact(0).normal);

            //BulletMovement bullet_movement = collision.gameObject.GetComponent<BulletMovement>();

            //velNor = Vector3.Dot(gameObject.GetComponent<BulletMovement>().Speed, collision.GetContact(0).normal);
            //velTan = Vector3.Cross(gameObject.GetComponent<BulletMovement>().Speed, collision.GetContact(0).tangentImpulse);
            //newDir = Vector3.Normalize(velNor + velTan);
            //GetComponent<BulletMovement>().SetDirection(newDir);
            BulletMovement bullet_movement = collision.gameObject.GetComponent<BulletMovement>();
            Vector3 oldSpeed = bullet_movement.Speed;
            bullet_movement.SetDirection(new Vector3(oldSpeed.x * collision.GetContact(0).normal.x * -1, oldSpeed.x * collision.GetContact(0).normal.x, 0));

            //3 INSTRUCCIONES
            // 
            // cross con zeta
            // direccion final = tanegncial + normal
        }
        
    }
    #endregion
}
