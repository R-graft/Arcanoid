using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameBackPanel : LevelAttributes
{
    [SerializeField]
    private TextMeshProUGUI _levelValue;

    [SerializeField]
    private Image _levelLogo;

   
    private void Awake()
    {
        _levelLogo.sprite = _currentLevelImage;

        _levelValue.text = _currentLevelProgress;
    }
}
