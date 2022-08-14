using UniRx;
using UnityEngine;

public class MoveBeforeStart : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _ballRb;

    [SerializeField]
    private BallMove _ballMove;

    [SerializeField]
    private Transform _platformTransform;

    private CompositeDisposable _disposables = new CompositeDisposable();

    private Vector2 _startPosition;

    private float _ballDisposition;

    private void Awake()
    {
        _ballDisposition = 0.9f;
    }
    private void Start()
    {
        MoveBall();
    }
    private void MoveBall()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetMouseButton(0))
            {
                FollowPlatform();
            }
            if (Input.GetMouseButtonUp(0))
            {
                _ballMove.StartMove();

                _disposables.Clear();
            }

        }).AddTo(_disposables);
    }
    private void FollowPlatform()
    {
        _startPosition = new Vector2((_platformTransform.position.x) / _ballDisposition, _ballRb.position.y);

        _ballRb.position = _startPosition;
    }
}
