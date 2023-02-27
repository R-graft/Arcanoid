using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Vector2 _leftUpPosition;

    private const int _rowsCount = 10;

    private const int _linesCount = 10;

    private const float _heightOffset = 0.83f;

    private const float _widthOffset = 0.05f;

    public Dictionary<(int,int), Vector2> gridPositions = new Dictionary<(int, int), Vector2>();

    public Dictionary<(int, int), Vector2> CreateGrid()
    {
        _leftUpPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * _widthOffset, (Screen.height * _heightOffset)));

        var cellLength = (-_leftUpPosition.x * 2) / _rowsCount;

        var cellHeight = cellLength / 2;

        Vector2 startPoint = (_leftUpPosition + new Vector2(cellLength / 2, -cellHeight / 2));

        var tempPos = startPoint;

        for (int i = 1; i <= _linesCount; i++)
        {
            for (int j = 1; j <= _rowsCount; j++)
            {
                gridPositions.Add((i, j), tempPos);

                tempPos.x += cellLength;
            }

            tempPos.y -= cellHeight;

            tempPos.x = startPoint.x;
        }

        return gridPositions;
    }
}
