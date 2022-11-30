using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : Singleton<ScenesManager>
{
    public GameObject sceneTransition;

    private float _transitionTime = 1.5f;

    private AsyncOperation _loadingScene;


    public void Init()
    {
        SingleInit();

        Events.LoadScene.AddListener(LoadScene);

    }
    public void LoadScene(SCENELIST targetScene)
    {

        SceneManager.LoadSceneAsync(targetScene.ToString());
        // StartCoroutine(SceneLoadCoroutine(targetScene));
    }

    private IEnumerator SceneLoadCoroutine(SCENELIST targetScene)
    {
        GameObject transitionObject = Instantiate(sceneTransition);

        yield return new WaitForSecondsRealtime(_transitionTime);

        _loadingScene = SceneManager.LoadSceneAsync(targetScene.ToString());

        while (!_loadingScene.isDone)
        {
            yield return null;
        }

        Destroy(transitionObject);
    }
   
}
