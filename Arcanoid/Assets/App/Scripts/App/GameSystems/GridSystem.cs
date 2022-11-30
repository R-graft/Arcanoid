using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private Grid _grid;

    public static Dictionary<(int x, int y), Block> _gridIndexes;

    public Dictionary<(int x, int y), Vector2> _gridWorldPositions;

    private bool _isInited;

    public void Init()
    {
        if (!_isInited)
        {
            _grid = new Grid();

            _gridWorldPositions = _grid.CreateGrid();

            _isInited = true;
        }

        _gridIndexes = new Dictionary<(int x, int y), Block>();
    }
}
