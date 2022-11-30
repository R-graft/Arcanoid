using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BonusAttach : MonoBehaviour
{
    [SerializeField]
    private Bonus _bonus;

    [SerializeField]
    private SpriteRenderer _renderer;

    [SerializeField]
    private BonusMove _bonusMove;

    public static List<Bonus> _activeBonuses;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            if (_activeBonuses == null)
            {
                _activeBonuses = new List<Bonus>();
            }
            if (_activeBonuses.Count > 0)
            {
                foreach (var item in _activeBonuses)
                {
                    if (item.GetType() == _bonus.GetType())
                    {
                        item.StopAndRemove();
                        break;
                    }
                }
            }
            Attach(collision.gameObject.transform);

            _bonus.Apply();

            _activeBonuses.Add(GetComponent<Bonus>());
        }
    }
    private void Attach(Transform _transform)
    {
        transform.SetParent(_transform);

        transform.localPosition = Vector3.zero;

        _renderer.enabled = false;

        _bonusMove.enabled = false;
    }
}

