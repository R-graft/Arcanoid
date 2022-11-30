public class PauseWindow : UIWindow
{
    public void OnButtonPause()
    {
        LevelController.OnChangeGameState?.Invoke(GAMESTATUSES.OnPaused);
    }

    public void OnButtonExitToMenu()
    {
        Events.LoadScene.Invoke(SCENELIST.PackScene);
    }
}
