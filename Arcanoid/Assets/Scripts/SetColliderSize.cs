using UnityEngine;
public class SetColliderSize : MonoBehaviour
{
    private BoxCollider2D _objectCollider;

    private RectTransform _objectTransform;

    private void Awake()
    {
        _objectCollider = GetComponent<BoxCollider2D>();

        _objectTransform = GetComponent<RectTransform>();
    }
    void Start()
    {
        SetSizeCollider();
    }
    private void SetSizeCollider()
    {
        _objectCollider.size = new Vector2(_objectTransform.rect.width, _objectTransform.rect.height);
    }
}
