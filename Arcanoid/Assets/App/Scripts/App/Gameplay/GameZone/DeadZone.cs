using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bonus bonus))
        {
            Destroy(bonus.gameObject);
        }

        if (collision.TryGetComponent(out Rigidbody2D rb))
        {
            BallsController.OnDestroyBall.Invoke(rb);

            GameplaySystem.BallsCounter.Invoke(false);
        }
    }
}
