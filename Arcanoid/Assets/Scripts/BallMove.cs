using UnityEngine;
using UniRx;

public class BallMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _platformRb;

    private Rigidbody2D _objectRb;

    private CompositeDisposable _disposables = new CompositeDisposable();

    private Vector2 _startDirection;

    private Vector2 _startPosition;

    private float _ballDisposition;

    private float _forceIndex;


    private void Awake()
    {
        _objectRb = GetComponent<Rigidbody2D>();

        _ballDisposition = 0.9f;

        _forceIndex = 0.01f;
    }
    void Start()
    {
        //StartMove();

        MoveBeforeStart();
    }

    private void FollowPlatform()
    {
        _startPosition = new Vector2((_platformRb.position.x) / _ballDisposition, _objectRb.position.y);

        _objectRb.position = _startPosition;
    }
    public void StartMove()
    {
        _startDirection = new Vector2((_objectRb.position.x) * _forceIndex, _forceIndex * 2);

        _objectRb.AddForce(_startDirection);
    }
    private void MoveBeforeStart()
    {
        Observable.EveryUpdate().Subscribe(_ => 
        { 
            FollowPlatform();

            if (_objectRb.velocity.y > 1)
            {
                _disposables.Clear();
            }
        }).AddTo(_disposables);
    }
}
