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
    private float _horizontalOffset = 6.0f;
    /// <summary>
    /// Vertical distance from Camera to CameraTarget.
    /// </summary>
    [SerializeField]
    private float _verticalOffset = 3.0f;
    /// <summary>
    /// Multiplier factor to regulate camera responsiveness to target's movement.
    /// </summary>
    [SerializeField]
    private float _followFactor = 5.0f;
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
        _yFollowEnabled = verticalFollowEnabled;
    }
    #endregion

    /// <summary>
    /// START
    /// Needs to assign _myTransform and initialize _yPreviousFrameValue
    /// </summary>
    void Start()
    {
        _myTransform = transform;
        
        _myTransform.position = _targetTransform.position - _horizontalOffset * Vector3.forward + _verticalOffset * Vector3.up;

        _myTransform.LookAt(_targetTransform);

        _yPreviousFrameValue = _targetTransform.position.y;
    }
    /// <summary>
    /// LATE UPDATE
    /// Needs to calculate the desired position for the camera.
    /// This calculation will differ depending on _yFollowEnabled.
    /// Once calculated, the new camera position can be assigned accorging to it, in a smoothed way.
    /// </summary>
    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(_targetTransform.position.x, _yPreviousFrameValue, _targetTransform.position.z) - _horizontalOffset * Vector3.forward + _verticalOffset * Vector3.up;

        if (_yFollowEnabled)
        {
            _yPreviousFrameValue = _targetTransform.position.y;
        }

        _myTransform.position = Vector3.Lerp(_myTransform.position, targetPosition, _followFactor * Time.deltaTime);

        _myTransform.LookAt(_targetTransform);
    }
}
