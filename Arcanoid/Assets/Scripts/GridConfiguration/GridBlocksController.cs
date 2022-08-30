using UnityEngine;
using UnityEngine.UI;

public class GridBlocksController : MonoBehaviour
{
    private GridLayoutGroup _gridLayoutGroup;

    private void Awake()
    {
        _gridLayoutGroup = GetComponent<GridLayoutGroup>();

        _gridLayoutGroup.enabled = true;
    }

    private void OffGrid(int a)
    {
        _gridLayoutGroup.enabled = false;
    }
    private void OnEnable()
    {
        LevelLoader.onBlocksCreated += OffGrid;
    }
    private void OnDisable()
    {
        LevelLoader.onBlocksCreated -= OffGrid;
    }
}
