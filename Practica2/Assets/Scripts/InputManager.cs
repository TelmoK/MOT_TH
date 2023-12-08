using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to Player's CharacterMovement component, to be set from editor first time,
    /// and reassigned in run time for subsequent times.
    /// </summary>
    [SerializeField]
    private CharacterMovement _playerCharacterMovement;
    #endregion

    #region methods
    /// <summary>
    /// Public method to allow CharacterMovement to register on InputManager so it can receive input.
    /// </summary>
    /// <param name="playerCharacterMovement">Player's CharacterMovement (Component to be reigstered)</param>
    public void RegisterPlayer(CharacterMovement playerCharacterMovement)
    {
        if (!playerCharacterMovement)
        {
            _playerCharacterMovement = playerCharacterMovement;
        }
        
    }
    #endregion

    /// <summary>
    /// UPDATE
    /// Receive Horizontal input from player, if any, and set it on Player's CharacterMovement
    /// Receive Vertical input from player, if any, and set it on Player's CharacterMovement
    /// Receive Jump input from player, if any, and call corresponding method on Player's CharacterMovement
    /// </summary>
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerCharacterMovement.SetHorizontalInput(horizontalInput);

        float verticalInput = Input.GetAxisRaw("Vertical");
        _playerCharacterMovement.SetVerticalInput(verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerCharacterMovement.Jump();
        }
    }
}