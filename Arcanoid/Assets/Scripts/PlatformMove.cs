using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField]
    private Transform _moveConstrainter;

    private Rigidbody2D _objectRb;
    
    private float _xDirection;

    private float _moveSpeed;

    private Vector2 _moveDirection;

    private float _yPosition;

    private float _halfScale;
    private void Awake()
    {
        _objectRb = GetComponent<Rigidbody2D>();

        _yPosition = _objectRb.position.y;

        _moveSpeed = 0.5f;

        _halfScale = gameObject.transform.localScale.x / 2;
    }

    private void FixedUpdate()
    {
        _xDirection = Mathf.Clamp(_xDirection, _moveConstrainter.position.x + _halfScale, -_moveConstrainter.position.x - _halfScale);

        _moveDirection = new Vector2(_xDirection, _yPosition);

        _objectRb.position = Vector2.MoveTowards(_objectRb.position, _moveDirection, _moveSpeed);
    }
    private void GetDirection(float inputDirection)
    {
        _xDirection = inputDirection;
    }

    private void OnEnable()
    {
        PlayerInputs.OnMove += GetDirection;
    }
    private void OnDisable()
    {
        PlayerInputs.OnMove -= GetDirection;
    }
}
