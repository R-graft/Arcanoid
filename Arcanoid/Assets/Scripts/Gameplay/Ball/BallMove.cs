using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D _objectRb;

    private Vector2 _startDirection;

    private float _startForceIndex;

    private float _gameForceIndex;

    private void Awake()
    {
        _objectRb = GetComponent<Rigidbody2D>();

        _startForceIndex = 0.02f;

        _gameForceIndex = 0.0001f;
    }

    public void StartMove()
    {
        _startDirection = new Vector2(_objectRb.position.x, 1).normalized;

        _objectRb.AddForce(_startDirection * _startForceIndex);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "block")
        {
            _objectRb.AddForce(-_objectRb.position  * _gameForceIndex);
        }
    }
}
