using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    private int _ballCount = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_ballCount == 1)
        {
            Events.loseBall.Invoke();
        }
    }
}
