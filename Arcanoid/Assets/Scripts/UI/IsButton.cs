using UnityEngine;

public class IsButton : MonoBehaviour
{
    private ScenesManager _sceneChanger = new ScenesManager();

    public void LoadScene(int sceneIndex) 
    { 
        _sceneChanger.LoadScene(sceneIndex);
    }

    public void ReloadScene()
    {
        _sceneChanger.ReloadScene();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
