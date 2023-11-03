using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    /// <summary>
    /// Reference to Player's CharacterMovement component, to be set from editor
    /// </summary>
    [SerializeField]
    private CharacterMovement _playerCharacterMovement;
    /// <summary>
    /// Called every frame.
    /// Needs to assign horizontal and vertical axis for Player's Character Movement.
    ///
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _playerCharacterMovement.SetHorizontalInput(1);
        }
        else if (Input.GetKey(KeyCode.A)) _playerCharacterMovement.SetHorizontalInput(-1);
        else _playerCharacterMovement.SetHorizontalInput(0);

        if (Input.GetKey(KeyCode.W))
        {
            _playerCharacterMovement.SetVerticalInput(1);
        }
        else if (Input.GetKey(KeyCode.S)) _playerCharacterMovement.SetVerticalInput(-1);
        else _playerCharacterMovement.SetVerticalInput(0);

    }
}