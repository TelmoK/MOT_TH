using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimationComponent : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to player's Character Controller.
    /// Needs to be assigned on Start
    /// </summary>
    private CharacterController _myCharacterController;
    /// <summary>
    /// Reference to player's Animator.
    /// Needs to be assigned on Start.
    /// </summary>
    private Animator _myAnimator;
    #endregion

    /// <summary>
    /// START
    /// Assign _myCharacterController and _myAnimator
    /// Check if both are correct or disable component
    /// </summary>
    void Start()
    {
        // Programación defensiva
        _myCharacterController = GetComponent<CharacterController>();
        if (_myCharacterController == null)
        {
            Debug.LogError("CharacterController not found on the GameObject.");
        }
        // Programación defensiva
        _myAnimator = GetComponent<Animator>();
        if (_myCharacterController == null)
        {
            Debug.LogError("Animator not found on the GameObject.");
        }
    }
    /// <summary>
    /// UPDATE
    /// Evaluate _myCharacterController velocity
    /// Assign the right animation according to this using integer parameter "AnimState"
    /// </summary>
    void Update()
    {
        Vector3 chVelocity = _myCharacterController.velocity;
        Debug.Log("IN ANIM "+ chVelocity); // PROBLEMA: La velocidad siempre es (0,0,0) NO SE CUMPLEN LOS CONDICIONALES

        if (_myCharacterController.isGrounded && Mathf.Approximately(chVelocity.magnitude, 0.0f))
        {
            Debug.Log("IDLE");
            _myAnimator.SetInteger("AnimState", 0);
        }
        else if(_myCharacterController.isGrounded && chVelocity.y > 0)
        {
            Debug.Log("JUMP");
            _myAnimator.SetInteger("AnimState", 2);
        }
        else if(!_myCharacterController.isGrounded && chVelocity.y < 0)
        {
            Debug.Log("FALL");
            _myAnimator.SetInteger("AnimState", 3);
        }
        else if(_myCharacterController.isGrounded && (chVelocity.x != 0f || chVelocity.z != 0f))
        {
            Debug.Log("RUN");
            _myAnimator.SetInteger("AnimState", 1);
        }
    }
}
