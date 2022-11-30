public class LoseWindow : UIWindow
{
    public void OnButtonContinueGame()
    {
        LevelController.OnChangeGameState.Invoke(GAMESTATUSES.OnGame);
    }
}
