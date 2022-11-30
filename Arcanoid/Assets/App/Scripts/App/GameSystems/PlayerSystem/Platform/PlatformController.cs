using System;
using UnityEngine;

public class PlatformController :MonoBehaviour
{
    [SerializeField]
    private Transform _platformTransform;

    [SerializeField]
    private Inputs _inputs;

    private float _moveConstrainterX;

    private  float _moveSpeed = 0.5f;

    private float _yPosition;

    private float _scale;

    public static Action<float> ResizePlatform;

    public static Action<bool> SetPlatformSpeed;

    public void Init(Vector2 startPos)
    {
        transform.position = startPos;

        _scale = _platformTransform.localScale.x / 2;

        _yPosition = _platformTransform.position.y;

        _moveConstrainterX = Camera.main.ScreenToWorldPoint(Vector2.zero).x;
    }
    private void FixedUpdate()
    {
        var _xDirection = Mathf.Clamp(_inputs._inputPositionX, _moveConstrainterX + _scale, -_moveConstrainterX - _scale);

        var moveDirection = new Vector2(_xDirection, _yPosition);

        _platformTransform.position = Vector2.MoveTowards(_platformTransform.position, moveDirection, _moveSpeed);
    }
    private void ChangeScale(float value)
    {
        _platformTransform.localScale = new Vector2(_platformTransform.localScale.x + value, _platformTransform.localScale.y);

        _scale = _platformTransform.localScale.x / 2;
    }

    private void ChangeSpeed(bool isSpeedUp)
    {
        if (isSpeedUp)
        {
            _moveSpeed *= 3;
        }
        else
        {
            _moveSpeed /= 3;
        }
    }
    public Transform GetTransform()
    {
        return _platformTransform;
    }
    private void OnEnable()
    {
        ResizePlatform += ChangeScale;
        SetPlatformSpeed += ChangeSpeed;
    }
    private void OnDisable()
    {
        ResizePlatform -= ChangeScale;
        SetPlatformSpeed -= ChangeSpeed;
    }
}
