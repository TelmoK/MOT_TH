using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    #region paramaters
    /// <summary>
    /// Movement speed of the player. Needs to keep constant while the player moves
    /// </summary>
    [SerializeField]
    private float _movementSpeed = 3.0f;
    /// <summary>
    /// Vertical speed assigned to character when jump starts
    /// </summary>
    [SerializeField]
    private float _jumpSpeed = 20.0f;
    /// <summary>
    /// Minimum vertical speed to limitate falling speed
    /// </summary>
    [SerializeField]
    private float _minSpeed = -10.0f;
    #endregion

    #region references
    /// <summary>
    /// Reference to Player's character controller
    /// </summary>
    private CharacterController _myCharacterController;
    /// <summary>
    /// Reference to Player's Transform
    /// </summary>
    private Transform _myTransform;
    /// <summary>
    /// Reference to Camera's CameraController
    /// </summary>
    private CameraController _cameraController;
    #endregion

    #region properties
    /// <summary>
    /// Horizontal component of the movement direction
    /// </summary>
    private float _xAxis;
    /// <summary>
    /// Vertical component of the movement direction
    /// </summary>
    private float _zAxis;
    /// <summary>
    /// Movement direction vector
    /// </summary>
    private Vector3 _movementDirection;
    /// <summary>
    /// Movement vertical speed (needs to be updated every frame due to gravity)
    /// </summary>
    private float _verticalSpeed;
    #endregion

    #region methods
    /// <summary>
    /// Public method to set the horizontal component of input. (Will be called from InputManager)
    /// </summary>
    /// <param name="x">Received horizontal component</param>
    public void SetHorizontalInput(float x)
    {
        _xAxis = x;
    }
    /// <summary>
    /// Public method to set the vertical component of input. (Will be called from InputManager)
    /// </summary>
    /// <param name="y">Received vertical component</param>
    public void SetVerticalInput(float y)
    {
        _zAxis = y;
    }
    /// <summary>
    /// Public method called when the player tries to perform a new Jump. (Will be called from InputManager)
    /// If the Character is grounded, it overrides current value or _verticalSpeed with _jumpSpeed.
    /// Otherwise, the request to jump is ignored.
    /// </summary>
     public void Jump()
     {
        //TODO
        Debug.Log("Jumped");
     }

    #endregion
    /// <summary>
    /// START
    /// Needs to assign _myCharacterController, _myTransform and _cameraController.
    /// If InputManager is already assigned, it will also register the player on it.
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
        _cameraController = FindObjectOfType<CameraController>();
        if (_cameraController == null)
        {
            Debug.LogError("CameraController not found in the scene.");
        }
    
        _myTransform = transform;
    }
    /// <summary>
    /// UPDATE
    /// Needs to calculate and normalize horizontal movement direction
    /// Needs to update vertical speed according to gravity
    /// Finally move the character according to desired _movementSpeed in horizontal and updated _verticalSpeed
    /// Final details:
    /// -Ensure the character looks in the desired direction according to move direction.
    /// -Ensure to set the vertical following behaviour for camera depending on whether the character is grounded or not.
    /// </summary>
    void Update()
    {
        _myCharacterController.SimpleMove(new Vector3(_xAxis, 0, _zAxis) * _movementSpeed);
    }
}
