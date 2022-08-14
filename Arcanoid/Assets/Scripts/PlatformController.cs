using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private RectTransform _inputZone;

    [SerializeField]
    private Collider2D _platformCollider;

    private Camera _camera;

    private Transform _objectTransform;

    private Vector2 _inputPosition;

    private Vector2 _moveDirection;

    private void Awake()
    {
        _objectTransform = GetComponent<Transform>();

        _camera = Camera.main;

        _moveDirection = _objectTransform.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _inputPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            if (_inputPosition.y < _inputZone.position.y)
            {
                _moveDirection = new Vector2(_inputPosition.x, _objectTransform.position.y);
            }
        }
    }
    private void FixedUpdate()
    {
        _objectTransform.position = Vector2.MoveTowards(_objectTransform.position, _moveDirection, 0.3f); 
    }
}
