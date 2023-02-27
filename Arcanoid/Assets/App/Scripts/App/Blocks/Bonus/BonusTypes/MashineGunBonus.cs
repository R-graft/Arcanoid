using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashineGunBonus : Bonus
{
    [SerializeField]
    private Bullet _prefab;

    private ObjectPool<Bullet> _bulletPool;

    private List<Bullet> _bullets;

    private const int _bulletsPoolSize = 10;

    private float _offsetX = 0.3f;

    private const float _offsetY = 0.2f;

    public override void Apply()
    {
        StartCoroutine(Shooting());
    }

    public override void Remove()
    {
        StopAllCoroutines();

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();

        DestroyBullets();
    }

    private void OnEnable()
    {
        _bullets = new List<Bullet>();

        _bulletPool = new ObjectPool<Bullet>(() => CreateBullet(),
            bullet => bullet.gameObject.SetActive(false),
            bullet => bullet.gameObject.SetActive(true),
            bullet => bullet.gameObject.SetActive(false));

        for (int i = 0; i < _bulletsPoolSize; i++)
        {
            _bulletPool.CreatePoolObject();
        }

        BonusEvents.OnResizePlatform.AddListener(OnSetScale);
    }

    private IEnumerator Shooting()
    {
        int count = _bulletsPoolSize;

        while (count > 0)
        {
            var position = PlatformController.OnGetTransform.Invoke().position;

            var bullet1 = _bulletPool.Get();

            bullet1.transform.position = new Vector2(position.x + _offsetX, position.y + _offsetY);

            var bullet2 = _bulletPool.Get();

            bullet2.transform.position = new Vector2(position.x - _offsetX, position.y + _offsetY);

            count--;

            yield return new WaitForSecondsRealtime(0.5f);
        }

        Remove();
    }
    private Bullet CreateBullet()
    {
        var newBullet = Instantiate(_prefab, transform);

        newBullet.OnCeateBullet(_bulletPool);

        _bullets.Add(newBullet);

        return newBullet;
    }

    private void DestroyBullets()
    {
        foreach (var item in _bullets)
            Destroy(item.gameObject);
    }

    private void OnSetScale(float value)
    {
        _offsetX += value/2;
    }
}
