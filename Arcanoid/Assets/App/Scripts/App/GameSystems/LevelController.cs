using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private SpawnSystem _spawner;

    [SerializeField]
    private GameplaySystem _gameplay;

    [SerializeField]
    private PlayerSystem _player;

    [SerializeField]
    private GridSystem _grid;

    [SerializeField]
    private GameUI _gameUI;

    private const int EnergyIncreaseValue = 4;

    private const int EnergyDecreaseValue = 3;

    private GAMESTATUSES _status;

    public static Action<GAMESTATUSES> OnChangeGameState;

    private void Awake()
    {
        BeforeGameState();
    }

    private void BeforeGameState()
    {
        _grid.Init();

        _spawner.Init();

        var _levelData = new LevelDataLoader().GetCurrentLevelData();

        var _arranger = new BlocksArranger(_levelData);

        _arranger.ArrangeBlocks(_grid._gridWorldPositions);

        _gameplay.Init();

        GameProgressController.OnSetEnergy?.Invoke(false, EnergyDecreaseValue);

        PlayGameState();
    }

    private void PlayGameState()
    {
        _player.Init();

        _player.TurnOnInputSystem();
    }
    private void PauseState()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            _player.TurnOnInputSystem();
        }
        else
        {
            _player.TurnOffInputSystem();
            _gameUI.OnPause();
            Time.timeScale = 0;
        }
    }

    private void LoseState()
    {
        _player.TurnOffInputSystem();

        _gameUI.OnLose();
    }

    private void GameOverState()
    {
        _player.TurnOffInputSystem();

        _gameUI.OnGameOver();
    }

    private void WinState()
    {
        _player.TurnOffInputSystem();

        _player.SetStartState();

        _gameUI.OnWin();

        GameProgressController.OnSetEnergy?.Invoke(true, EnergyIncreaseValue);

        GameProgressController.OnPassLevel?.Invoke();
    }

    public void ChangeState(GAMESTATUSES status)
    {
        _status = status;

        switch (_status)
        {
            case GAMESTATUSES.BeforeStart:
                BeforeGameState();
                break;
            case GAMESTATUSES.OnGame:
                PlayGameState();
                break;
            case GAMESTATUSES.OnPaused:
                PauseState();
                break;
            case GAMESTATUSES.OnLose:
                LoseState();
                break;
            case GAMESTATUSES.OnWin:
                WinState();
                break;
            case GAMESTATUSES.OnGameOver:
                GameOverState();
                break;
        }
    }
    private void OnEnable()
    {
        OnChangeGameState += ChangeState;
    }
    private void OnDisable()
    {
        OnChangeGameState -= ChangeState;
    }
}
