using UnityEditor;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public void OnbuttonStartGame()
    {
        if (PlayerPrefs.HasKey("FirstIn"))
        {
            Events.LoadScene.Invoke(SCENELIST.PackScene);
        }
        else
        {
            PlayerPrefs.SetInt("FirstIn", default);

            Events.LoadScene.Invoke(SCENELIST.GameScene);
        }
    }

    public void OnButtonExitApplication()
    {
#if UNITY_EDITOR
        PlayerPrefs.DeleteKey("FirstIn");
        EditorApplication.isPlaying = false;
#endif
#if PLATFORM_ANDROID
        PlayerPrefs.DeleteKey("FirstIn");
		Application.Quit();
#endif
    }
}
