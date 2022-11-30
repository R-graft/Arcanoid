using System.Collections;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private Rigidbody2D _ballRb;

    private Transform _platformTransform;

    private Inputs _input;

    private const float _ballDisposition = 0.9f;

    private const float _ballOffset = 0.25f;

    private const float _startForceIndex = 0.02f;

    public void Init(Rigidbody2D ballRb, Transform platformTransform, Inputs input)
    {
        _ballRb = ballRb;

        _platformTransform = platformTransform;

        _input = input;

        StartCoroutine(LaunchBall());
    }

    private IEnumerator LaunchBall()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();

            var startPosition = new Vector2((_platformTransform.position.x) / _ballDisposition, _platformTransform.position.y + _ballOffset);

            _ballRb.position = startPosition;
            

            if (_input.isMouseUp)
            {
                var startDirection = -_ballRb.position.normalized;

                _ballRb.AddForce(startDirection * _startForceIndex);

                yield break;
            }
        }
    }
}
