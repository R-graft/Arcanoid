using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D _objectRb;

    private Vector2 _startDirection;

    private float _forceIndex;

    private void Awake()
    {
        _objectRb = GetComponent<Rigidbody2D>();

        _forceIndex = 0.02f;
    }

    public void StartMove()
    {
        _startDirection = new Vector2((_objectRb.position.x) * _forceIndex, _forceIndex);

        _objectRb.AddForce(_startDirection);
    }
}
