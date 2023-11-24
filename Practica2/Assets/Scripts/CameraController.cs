using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Horizonal distance from Camera to CameraTarget.
    /// </summary>
    [SerializeField]
    private float _horizontalOffset = 1.0f;
    /// <summary>
    /// Vertical distance from Camera to CameraTarget.
    /// </summary>
    [SerializeField]
    private float _verticalOffset = 1.0f;
    /// <summary>
    /// Multiplier factor to regulate camera responsiveness to target's movement.
    /// </summary>
    [SerializeField]
    private float _followFactor = 1.0f;
    #endregion

    #region references
    /// <summary>
    /// Camera target transform. Actually, the one the camera needs to follow.
    /// </summary>
    [SerializeField]
    private Transform _targetTransform;
    /// <summary>
    /// Reference to own transform.
    /// </summary>
    private Transform _myTransform;
    #endregion

    #region properties
    /// <summary>
    /// If disabled, the camera does not follow target in vertical axis and keeps its own Y coordinate.
    /// </summary>
    private bool _yFollowEnabled = true;
    /// <summary>
    /// Stores own previous position's Y coordinate, to be able to keep it in case vertical following is disabled.
    /// </summary>
    private float _yPreviousFrameValue;
    #endregion

    #region methods
    /// <summary>
    /// Public methods to allow others to set vertical following behaviour
    /// </summary>
    /// <param name="verticalFollowEnabled"></param>
    public void SetVerticalFollow(bool verticalFollowEnabled)
    {
        _yFollowEnabled = verticalFollowEnabled; //llama character
    }
    #endregion
    /// <summary>
    /// START
    /// Needs to assign _myTransform and initialize _yPreviousFrameValue
    /// </summary>
    void Start()
    {
        _myTransform = transform;
        _myTransform.LookAt(_targetTransform);
        _myTransform.position = _targetTransform.position - _horizontalOffset*Vector3.forward + _verticalOffset*Vector3.up;

        _yPreviousFrameValue = _myTransform.position.z;
    }
    /// <summary>
    /// LATE UPDATE
    /// Needs to calculate the desired position for the camera.
    /// This calculation will differ depending on _yFollowEnabled.
    /// Once calculated, the new camera position can be assigned accorging to it, in a smoothed way.
    /// </summary>
    void LateUpdate()
    {
        if (_yFollowEnabled)
        {
            _myTransform.position = Vector3.Lerp(_myTransform.position, _targetTransform.position, _followFactor * Time.deltaTime);
        }
        else
        {
            _myTransform.position = Vector3.Lerp(new Vector3(_myTransform.position.x, _myTransform.position.y, _yPreviousFrameValue), _targetTransform.position, Time.deltaTime * _followFactor);
        }
        _myTransform.LookAt(_targetTransform);


    }

}