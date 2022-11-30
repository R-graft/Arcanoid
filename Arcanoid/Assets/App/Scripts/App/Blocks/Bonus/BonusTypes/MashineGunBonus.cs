using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashineGunBonus : Bonus
{
    [SerializeField]
    private Bullet _prefab;

    private List<Bullet> _bulletsPool;

    private const int _bulletsPoolSize = 10;

    private const float _offsetX = 0.45f;

    private const float _offsetY = 0.2f;

    public override void Apply()
    {
        StartCoroutine(Shooting());

        StartTimer();
    }

    public override void Remove()
    {
        foreach (var item in _bulletsPool)
        {
            Destroy(item.gameObject);
        }
    }

    private void OnEnable()
    {
        _bulletsPool = new List<Bullet>();

        for (int i = 0; i < _bulletsPoolSize; i++)
        {
            CreateBullet();
        }
    }

    private IEnumerator Shooting()
    {
        int count = _bulletsPoolSize;

        while (count > 0)
        {
            var bullet1 = GetBullet();

            bullet1.transform.position = new Vector2(transform.position.x + _offsetX, transform.position.y + _offsetY);

            var bullet2 = GetBullet();

            bullet2.transform.position = new Vector2(transform.position.x - _offsetX, transform.position.y + _offsetY);

            count--;

            yield return new WaitForSecondsRealtime(1);
        }

        Remove();
    }

    private Bullet GetBullet()
    {
        foreach (var item in _bulletsPool)
        {
            if (!item.isActiveAndEnabled)
            {
                item.gameObject.SetActive(true);

                item.transform.parent = null;

                return item;
            }
        }

        CreateBullet();

        return GetBullet();
    }
    private void CreateBullet()
    {
        var newBullet = Instantiate(_prefab, transform);

        newBullet.gameObject.SetActive(false);

        _bulletsPool.Add(newBullet);
    }
}
