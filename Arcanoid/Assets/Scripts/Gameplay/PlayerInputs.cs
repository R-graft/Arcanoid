using UnityEngine;
using System;

public class PlayerInputs : MonoBehaviour
{
    [HideInInspector]
    public float _inputDirection;

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
        }
    }
}
