using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    #region(gameplay)
    public static UnityEvent<SCENELIST> LoadScene = new UnityEvent<SCENELIST>();

    public static UnityEvent<Block> blockDestroyed = new UnityEvent<Block>();

    public static UnityEvent ballIsFall = new UnityEvent();
    #endregion

    public static UnityEvent<bool> ActionOnEndLevel = new UnityEvent<bool>();

    public static UnityEvent sceneLoaded = new UnityEvent();
}
