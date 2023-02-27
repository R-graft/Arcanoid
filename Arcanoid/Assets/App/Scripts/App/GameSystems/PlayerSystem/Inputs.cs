using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inputs : Singleton<Inputs>
{
    [SerializeField]
    private EventSystem _eventSystem;

    private const float _inputConstrainterY = 0;

    public static Action<float> _inputPositionX;

    public static Action OnMouseUp, OnMouseDown;

    public Camera _camera;

    private bool _updateButtons;

    public void Init()
    {
        SingleInit();

        _updateButtons = false;
    }

    public void TurnOff(bool allSystem)
    {
        if (allSystem)
        {
            _eventSystem.enabled = false;
        }
        _updateButtons = false;
    }

    public void TurnOn(bool allSystem)
    {
        if (!_camera)
        {
            _camera = Camera.main;
        }

        if (allSystem)
        {
            _eventSystem.enabled = true;
        }
        _updateButtons = true;
    }
  
    
    public void Update()
    {
        if (_updateButtons)
        {
            if (Input.GetMouseButton(0))
            {
                if (_camera.ScreenToWorldPoint(Input.mousePosition).y < _inputConstrainterY)
                {
                    _inputPositionX?.Invoke(_camera.ScreenToWorldPoint(Input.mousePosition).x);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                OnMouseDown?.Invoke();
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnMouseUp?.Invoke();
            }
        }
    }
}
