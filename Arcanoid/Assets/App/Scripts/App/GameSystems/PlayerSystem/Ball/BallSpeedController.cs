using System;
using UnityEngine;

public class BallSpeedController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _objectRb;

    private const float _accelerationIndex = 1.02f;

    private const float _accelerationBonusIndex = 2f;

    private const float _maxVelocityValue = 12;

    private const float _minVelocityValue = 2;

    public static Action<bool> SwitchSpeed;

    public void SpeedCollisionCorrection()
    {
        if (_objectRb.velocity.magnitude < _maxVelocityValue)
        {
            _objectRb.velocity *= _accelerationIndex;
        }
    }

    public void SpeedEdit(bool isSpeedUp)
    {
        if (isSpeedUp && _objectRb.velocity.magnitude < _maxVelocityValue)
        {
            _objectRb.velocity *= _accelerationBonusIndex;

            return;
        }

        if (!isSpeedUp && _objectRb.velocity.magnitude > _minVelocityValue)
        {
            _objectRb.velocity /= _accelerationBonusIndex;
        }
    }

    private void OnEnable()
    {
        SwitchSpeed += SpeedEdit;
    }

    private void OnDisable()
    {
        SwitchSpeed -= SpeedEdit;
    }
}
