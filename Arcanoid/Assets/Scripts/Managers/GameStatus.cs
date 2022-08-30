using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : Singleton<GameStatus>
{
    private enum GAMESTATUSES
    {
        BeforeStart,
        InGame,
        OnPaused,
        OnLose,
        OnWin,
        OnGameOver
    }

}
