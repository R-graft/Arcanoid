using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinSceneController : LevelAttributes
{
    [SerializeField]
    private Image _levelLogo;

    [SerializeField]
    private Slider _levelProgress;

    [SerializeField]
    private TextMeshProUGUI _levelName;

    [SerializeField]
    private TextMeshProUGUI _energy;

    private void Awake()
    {
        _levelName.text = _currentPackName;

        _levelLogo.sprite = _currentLevelImage;
    }
}
