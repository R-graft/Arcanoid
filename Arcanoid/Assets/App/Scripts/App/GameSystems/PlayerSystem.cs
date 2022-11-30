using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField]
    private BallsController _ballsController;

    [SerializeField]
    private BallLauncher _launcher;

    [SerializeField]
    private Inputs _inputs;

    [SerializeField]
    private PlatformController _platform;

    private Vector2 _startBallPosition = new Vector2(0, -2.85f);

    private Vector2 _startPlatformPosition = new Vector2(0, -3.2f);

    public void Init()
    {
        _platform.Init(_startPlatformPosition);

        _ballsController.Init(_startBallPosition);

        _launcher.Init(_ballsController.GetRb(0), _platform.GetTransform(), _inputs);
    }

    public void TurnOnInputSystem()
    {
        _inputs.TurnOn();
    }

    public void TurnOffInputSystem()
    {
        _inputs.TurnOff();
    }
   
    public void SetStartState()
    {
        _ballsController.StopBallMove();

        _ballsController.SetBallsInPosition(_startBallPosition);

        _platform.GetTransform().position = _startPlatformPosition;
    }
}
