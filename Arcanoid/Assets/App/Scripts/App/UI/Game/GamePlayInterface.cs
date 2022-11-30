using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayInterface :MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _levelValue;

    [SerializeField]
    private Image _levelLogo;

    [SerializeField]
    private Slider _levelProgressSlider;

    [SerializeField]
    private TextMeshProUGUI _packName;

    [SerializeField]
    private GameObject _livesPanel;

    [SerializeField]
    private GameObject _lifePrefab;

    [SerializeField]
    private PacksData _packsData;

    private float _currentBlocksCount;

    private float _progressStep;

    public void Init(int lives, int blocksCount)
    {
        if (GameProgressController.instance)
        {
            var progress = GameProgressController.instance;

            _levelValue.text = $"{_packsData.packsModels[progress.PackIndex].EndedLevel}";

            _packName.text = _packsData.packsModels[progress.PackIndex].title;

            _levelLogo.sprite = _packsData.packsModels[progress.PackIndex].sprite;

            _levelProgressSlider.value = 0;

            _currentBlocksCount = blocksCount;

            _progressStep = 1 / _currentBlocksCount;

            SetStatrtLives(lives);
        }

        else
        {
            Debug.Log("GameProgress not exist");
        }
    }
    public void LivesCounter(int lives, bool add)
    {
        if (add)
        {
            for (int i = 0; i < lives; i++)
            {
                if (_livesPanel.transform.childCount < 5)
                {
                    Instantiate(_lifePrefab, _livesPanel.transform);
                }
            }
        }

        else
        {
            for (int i = 0; i < lives; i++)
            {
                if (_livesPanel.transform.childCount > 0)
                {
                    Destroy(_livesPanel.transform.GetChild(0).gameObject);
                }
            }
        }
    }

    public void SetStatrtLives(int startLives)
    {
        if (_livesPanel.transform.childCount < startLives)
        {
            while (_livesPanel.transform.childCount != startLives)
            {
                LivesCounter(1, true);
            }
        }
        else if (_livesPanel.transform.childCount > startLives)
        {
            while (_livesPanel.transform.childCount != startLives)
            {
                LivesCounter(1, false);
            }
        }
    }
    public void OnBlockDestroy()
    {
        _levelProgressSlider.value += _progressStep;
    }

    public void OnPauseButtonDown()
    {
        LevelController.OnChangeGameState.Invoke(GAMESTATUSES.OnPaused);
    }
}
