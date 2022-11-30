using UnityEngine;

public class Inputs : MonoBehaviour
{
    private const float _inputConstrainterY = 0;

    public float _inputPositionX;

    public bool isMouseButton;

    public bool isMouseUp;

    public bool isMouseDown;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void TurnOn()
    {
        enabled = true;
    }
    public void TurnOff()
    {
        _inputPositionX = 0;

        isMouseButton = false;

        isMouseUp = false;

        isMouseDown = false;

        enabled = false;
    }
    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (_camera.ScreenToWorldPoint(Input.mousePosition).y < _inputConstrainterY)
            {
                _inputPositionX = _camera.ScreenToWorldPoint(Input.mousePosition).x;

                isMouseButton = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseUp = true;

            isMouseButton = false;
        }
    }
    private void LateUpdate()
    {
        isMouseButton = false;

        isMouseDown = false;
    }
}
