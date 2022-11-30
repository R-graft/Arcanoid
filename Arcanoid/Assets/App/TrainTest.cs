using UnityEngine;

public class TrainTest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if( collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damage))
        {

        }
    }
}
