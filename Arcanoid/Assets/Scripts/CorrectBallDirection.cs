using UnityEngine;

public class CorrectBallDirection : MonoBehaviour
{
    private Rigidbody2D _objectRb;

    private Vector2 _priviousPosition;

    private Vector2 _currentPosition;

    private float _collisionAngle;

    private float _minBounseAngle;

    private float _forceIndex;

    private void Awake()
    {
        _objectRb = GetComponent<Rigidbody2D>();

        _minBounseAngle = 2;

        _forceIndex = 0.001f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "edge")
        {
            _currentPosition = collision.contacts[0].point;

            Vector2 collisionNormal = collision.contacts[0].normal;

            _collisionAngle = Vector2.Angle(_priviousPosition - _currentPosition, collisionNormal);

            print(_collisionAngle);

            if (_collisionAngle < _minBounseAngle)
            {
                _objectRb.AddForce(new Vector2(collisionNormal.y, collisionNormal.x) * _forceIndex);
            }
            _priviousPosition = _currentPosition;
        }
    }
}
