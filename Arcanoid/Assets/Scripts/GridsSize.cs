using UnityEngine;
using UnityEngine.UI;

public class GridsSize : MonoBehaviour
{
    [SerializeField]
    private GameObject _panelObject;

    [SerializeField]
    private RectTransform _panelRect;

    private GridLayoutGroup _panelGrid;

    private float _panelWidth;

    private Vector2 _cellSize;

    private void Awake()
    {
        _panelGrid = GetComponent<GridLayoutGroup>();

        _panelWidth = _panelRect.rect.width;

        _cellSize = new Vector2(_panelWidth / 10, _panelWidth / 20);
    }
    void Start()
    {
        SetCellsSize();
    }
    private void SetCellsSize()
    {
        _panelGrid.cellSize = _cellSize;
    }
}
