using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private enum Scenes
    {
        StartScene,
        PackScene,
        GameScene,
        WinScene
    }

    private string loadingScene;

    private int _scenesLength;

    private void Awake()
    {
        _scenesLength = SceneManager.sceneCountInBuildSettings;
    }
    public void LoadScene(int index)
    {
        if (index < _scenesLength)
        {
            loadingScene = ((Scenes)index).ToString();

            SceneManager.LoadScene(loadingScene);
        }
        else
        {
            Debug.LogWarning("Scene not exist");
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
