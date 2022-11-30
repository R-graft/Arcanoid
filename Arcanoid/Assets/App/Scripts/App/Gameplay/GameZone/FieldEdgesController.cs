using UnityEngine;

public class FieldEdgesController : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D[] _edgesColliders;

    public void Init()
    {
        foreach (var item in _edgesColliders)
        {
            SetColliderSize(item, item.GetComponent<RectTransform>());
        }
    }

    private void SetColliderSize(BoxCollider2D collider, RectTransform rectTransform)
    {
        collider.size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);

        collider.offset = Vector2.zero;
    }
}
