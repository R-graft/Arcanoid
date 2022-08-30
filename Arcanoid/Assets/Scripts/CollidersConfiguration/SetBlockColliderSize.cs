using UnityEngine;
using UnityEngine.UI;

public class SetBlockColliderSize : MonoBehaviour
{
    private BoxCollider2D _objectCollider;

    private GridLayoutGroup _gridLayoutGroup;

    private void Awake()
    {
        _objectCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        _gridLayoutGroup = GetComponentInParent<GridLayoutGroup>();

        SetSizeCollider();
    }
    private void SetSizeCollider()
    {
        _objectCollider.size = _gridLayoutGroup.cellSize;
    }
}
