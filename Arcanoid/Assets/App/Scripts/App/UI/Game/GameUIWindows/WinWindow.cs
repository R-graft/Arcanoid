using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinWindow : UIWindow
{
    [SerializeField]
    private Image _levelLogo;

    [SerializeField]
    private Slider _levelProgress;

    [SerializeField]
    private TextMeshProUGUI _levelName;

    [SerializeField]
    private TextMeshProUGUI _energy;

    [SerializeField]
    private PacksData _packsData;

    [SerializeField]
    private Button _continue;

    private GameProgressController _progressController;

    public override void InitWindow()
    {
        if (GameProgressController.instance)
        {
            _progressController = GameProgressController.instance;

            var pack = _packsData.packsModels[_progressController.PackIndex];

            _levelLogo.sprite = pack.sprite;

            _levelName.text = pack.title;

            //_levelProgress.value = _progressController.Level / (item.startLevel + item.finishLevel);

            _energy.text = _progressController.Energy.ToString();
        }
        else
        {
            Debug.Log("Game progress not exist");
        }
    }

    public void OnButtonNextLevel()
    {
        LevelController.OnChangeGameState.Invoke(GAMESTATUSES.BeforeStart);
    }
}
