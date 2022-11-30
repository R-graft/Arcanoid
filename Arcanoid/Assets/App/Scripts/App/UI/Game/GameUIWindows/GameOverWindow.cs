using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : UIWindow
{
    [SerializeField]
    private Button _continueButton;

    private const int EnergyForContinue = 5;

    public override void InitWindow()
    {
        if (GameProgressController.instance.Energy >= EnergyForContinue)
        {
            _continueButton.enabled = true;
        }
        else
        {
            _continueButton.enabled = false;
        }
    }
    public void OnButtonExitToMenu()
    {
        Events.LoadScene.Invoke(SCENELIST.PackScene);
    }

    public void OnButtonContinueWihEnergy()
    {
        GameplaySystem.ChangeLives.Invoke(1, true);

        GameProgressController.OnSetEnergy.Invoke(false, EnergyForContinue);
    }
}
