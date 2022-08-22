using UnityEngine;
using System;

public class PlayerInputs : MonoBehaviour
{
    public static event Action<float> OnMove;

    private float _inputDirection = 0;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _inputDirection = _camera.ScreenToWorldPoint(Input.mousePosition).x;

            OnMove?.Invoke(_inputDirection);
        }
    }
}
