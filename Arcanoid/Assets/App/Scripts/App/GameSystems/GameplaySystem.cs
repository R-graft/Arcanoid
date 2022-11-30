using System;
using UnityEngine;

public class GameplaySystem: MonoBehaviour
{
    [SerializeField]
    private FieldEdgesController _edgeSystem;

    [SerializeField]
    private GamePlayInterface _interface;

    private int _ballsCount;

    private int _blocksCount;

    private const int StartLivesCount = 3;

    private int _livesCount;

    private bool IsInited;

    public static Action<int, bool> ChangeLives;

    public static Action<bool> BallsCounter;

    public void Init()
    {
        if (!IsInited)
        {
            Events.blockDestroyed.AddListener(BlockDestroyed);

            _edgeSystem.Init();

            IsInited = true;
        }

        _livesCount = StartLivesCount;

        _blocksCount = GridSystem._gridIndexes.Values.Count;

        _interface.Init(_livesCount, _blocksCount);
    }

    private void BlockDestroyed(Block block)
    {
        _blocksCount--;

        _interface.OnBlockDestroy();

        if (_blocksCount == 0)
        {
            LevelController.OnChangeGameState.Invoke(GAMESTATUSES.OnWin);
        }
    }

    private void ChangeBallsCount(bool isIncrement)
    {
        if (isIncrement)
        {
            _ballsCount++;
        }
        else
        {
            _ballsCount--;

            if (_ballsCount == 0)
            {
                ChangeLivesCount(1, false);
            }
        }
    }

    private void ChangeLivesCount(int value,bool islifeUp)
    {
        if (islifeUp)
        {
            _livesCount += value;

            _interface.LivesCounter(value, true);
        }

        else
        {
            _livesCount -= value;

            _interface.LivesCounter(value, false);

            if (_livesCount == 0)
            {
                LevelController.OnChangeGameState.Invoke(GAMESTATUSES.OnGameOver);
            }
            else
            {
                LevelController.OnChangeGameState.Invoke(GAMESTATUSES.OnLose);
            }
        }
    }
    private void OnEnable()
    {
        BallsCounter += ChangeBallsCount;

        ChangeLives += ChangeLivesCount;
    }

    private void OnDisable()
    {
        BallsCounter -= ChangeBallsCount;

        ChangeLives -= ChangeLivesCount;
    }
}
