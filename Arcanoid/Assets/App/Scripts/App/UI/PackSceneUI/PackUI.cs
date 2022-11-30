using UnityEngine;

public class PackUI : MonoBehaviour
{
    public void OnButtonToMenu()
    {
        Events.LoadScene.Invoke(SCENELIST.StartScene);
    }
}
