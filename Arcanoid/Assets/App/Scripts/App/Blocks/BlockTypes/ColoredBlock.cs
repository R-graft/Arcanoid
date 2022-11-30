using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColoredBlock : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _sprite;

    private Dictionary<int, Color> _colors = new Dictionary<int, Color>
    {
        { 1, Color.yellow },
        { 2, Color.green },
        { 3, Color.red },
        { 4, Color.black }
    };

    public void SetStartColor(int health)
    {
        _sprite.color = _colors[health];
    }

    public void SetColorOnDamage(int health)
    {
        _sprite.color = _colors[health];
    }
}
