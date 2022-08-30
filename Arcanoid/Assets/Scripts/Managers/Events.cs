using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
#region(gameplay)
    public static UnityEvent startBall = new UnityEvent();

    public static UnityEvent blockDestroyed = new UnityEvent();

    public static UnityEvent winLevel = new UnityEvent();

    public static UnityEvent loseBall = new UnityEvent();

    public static UnityEvent loseLevel = new UnityEvent();
    #endregion

    public static UnityEvent sceneLoaded = new UnityEvent();

    public static UnityEvent langChanged = new UnityEvent();
}
