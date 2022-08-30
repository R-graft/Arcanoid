using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleBlock : MonoBehaviour
{
    private Dictionary<int, Color> colors = new Dictionary<int, Color>
    {
        { 0, Color.yellow},
        { 1, Color.green},
        { 2, Color.red},
        { 3, Color.gray},
        { -1, Color.black}
    };

    public int blockHealth;

    private Image _blockImage;

    private void Awake()
    {
        _blockImage = GetComponent<Image>();
 
    }
    private void Start()
    {
        _blockImage.color = colors[blockHealth];
    }
    private void BlockDamage()
    {
        if (blockHealth > 0)
        {
            blockHealth--;

            SetBlockColor();
        }
        else if (blockHealth < 0)
        {
            return;
        }
        else
        {
            Events.blockDestroyed.Invoke();

            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BlockDamage();
    }
    private void SetBlockColor()
    {
        _blockImage.color = colors[blockHealth];
    }
}
