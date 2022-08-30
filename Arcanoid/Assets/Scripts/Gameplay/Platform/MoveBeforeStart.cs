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

    private float _ballDisposition = 0.9f;

    private float _ballOffset = 0.1f;

    private void Awake()
    {
        Events.loseBall.AddListener(MoveBall);
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
        _startPosition = new Vector2((_platformTransform.position.x) / _ballDisposition, _platformTransform.position.y + _ballOffset);

        _ballRb.velocity = Vector2.zero;

        _ballRb.position = _startPosition;
    }
}
