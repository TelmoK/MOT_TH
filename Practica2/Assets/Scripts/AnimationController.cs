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

        _myCharacterController = GetComponent<CharacterController>();
        if (_myCharacterController == null)
        {
            Debug.LogError("CharacterController not found on the GameObject.");
        }

        _myAnimator = GetComponent<Animator>();
        if (_myCharacterController == null)
        {
            Debug.LogError("Animator not found on the GameObject.");
        }

        if (!_myAnimator || !_myCharacterController)
        {
            enabled = false;
        }
    }

    /// <summary>
    /// UPDATE
    /// Evaluate _myCharacterController velocity
    /// Assign the right animation according to this using integer parameter "AnimState"
    /// </summary>
    void Update()
    {

        if (Mathf.Abs(_myCharacterController.velocity.y) > 0.1f)
        {
            //jump
           _myAnimator.SetInteger("AnimState", 2);
        }        
        else if (_myCharacterController.isGrounded && _myCharacterController.velocity.magnitude > 0.1f)
        {
            //move
            _myAnimator.SetInteger("AnimState", 1);
        }
        else if (_myCharacterController.isGrounded)
        {
            //idle
            _myAnimator.SetInteger("AnimState", 0);
        }
    }
}
