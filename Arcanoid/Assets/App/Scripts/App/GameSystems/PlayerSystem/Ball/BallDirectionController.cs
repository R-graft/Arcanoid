using UnityEngine;

public class BallDirectionController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _objectRb;

    private Vector2 _priviousPosition;

    private float _collisionAngle;

    private const float _minBounseAngle = 3;

    private const float _forceIndex = 0.002f;

    public void DirectCorrection(Collision2D collision)
    {
        var collisionNormal = collision.contacts[0].normal;

        var ballDirection = _priviousPosition - collision.contacts[0].point;

        _collisionAngle = Vector2.Angle(ballDirection, collisionNormal);

        if (_collisionAngle < _minBounseAngle)
        {
            _objectRb.AddForce(new Vector2(collisionNormal.y, collisionNormal.x) * _forceIndex);
        }
        _priviousPosition = collision.contacts[0].point;
    }
}
