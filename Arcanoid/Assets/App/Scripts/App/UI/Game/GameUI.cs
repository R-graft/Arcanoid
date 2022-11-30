using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private UIWindow _win;
    [SerializeField]
    private UIWindow _lose;
    [SerializeField]
    private UIWindow _pause;
    [SerializeField]
    private UIWindow _gameOver;

    private void Awake()
    {
        _win.HideWindow();
        _lose.HideWindow();
        _pause.HideWindow();
        _gameOver.HideWindow();
    }
    public void OnWin()
    {
        _win.InitWindow();

        _win.ShowWindow();
    }
    public void OnLose()
    {
        _lose.ShowWindow();
    }
    public void OnPause()
    {
        _pause.ShowWindow();
    }
    public void OnGameOver()
    {
        _gameOver.ShowWindow();
    }
}
