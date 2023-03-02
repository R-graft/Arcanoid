using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{    
    public static T Instance { get; private set; }

    public void SingleInit()
    {
        if (Instance == null)
        {
            Instance = (T)(object)this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
