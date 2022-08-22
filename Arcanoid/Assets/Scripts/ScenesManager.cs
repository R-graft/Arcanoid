using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ScenesManager
{
    private enum Scenes
    {
        StartScene,
        PackScene,
        GameScene,
        WinScene
    }

    string loadingScene;

    private int scenesLength = Enum.GetNames(typeof(Scenes)).Length;

    public void LoadScene(int index)
    {
        if (index <= scenesLength)
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
