using System;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _objectRb;

    [SerializeField]
    private BallSpeedController _movementController;

    [SerializeField]
    private BallDirectionController _directionController;

    private bool isFuryMode = false;

    private Vector2 _furyVelocity;

    public static Action<bool> SwitchCollisionMode;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MoveCorrection(collision);
    }

    private void MoveCorrection(Collision2D collision)
    {
        if (TryDamage(collision))
        {
            _movementController.SpeedCollisionCorrection();

            if (isFuryMode)
            {
                _objectRb.velocity = _furyVelocity;

                _furyVelocity = _objectRb.velocity;
            }
        }

        _directionController.DirectCorrection(collision);

        if (isFuryMode)
        {
            _furyVelocity = _objectRb.velocity;
        }
    }
    public void SetFuryMode(bool _isFuryMode)
    {
        isFuryMode = _isFuryMode;

        _furyVelocity = _objectRb.velocity;
    }

    private bool TryDamage(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damage))
        {
            if (isFuryMode)
            {
                damage.InDestroy();
            }

            damage.InDamage(1);

            return true;
        }
        return false;
    }

    private void OnEnable()
    {
        SwitchCollisionMode += SetFuryMode;
    }

    private void OnDisable()
    {
        SwitchCollisionMode -= SetFuryMode;
    }
}
