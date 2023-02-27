using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField]
    private Rigidbody2D rb;

    private ObjectPool<Bullet> _currentPool;

    private const int _bulletSpeed = 5;

    private const int _bulletDamage = 1;

    public void OnCeateBullet(ObjectPool<Bullet> pool)
    {
        _currentPool = pool;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damage))
        {
            damage.InDamage(_bulletDamage);
        }

        _currentPool.Disable(this);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.fixedDeltaTime);
    }
}
