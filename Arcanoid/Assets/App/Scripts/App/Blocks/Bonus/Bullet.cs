using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField]
    private Rigidbody2D rb;

    private const int _bulletSpeed = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damage))
        {
            damage.InDamage(1);

            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.fixedDeltaTime);
    }
}
