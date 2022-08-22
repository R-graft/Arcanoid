using System.Collections;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private BlockPool _blockPool;

    [SerializeField]
    private GameObject _blocksPanel;

    private LevelReader _levelReader;

    private LevelReader.LevelData levelData;

    private void Awake()
    {
        _levelReader = new LevelReader();
    }
    private void GetLevelData(string levelId)
    {
        levelData = _levelReader.GetFileData(levelId);
    }
    private void LoadLevel(string levelId)
    {
        GetLevelData(levelId);

        if (levelData.counts.Length == levelData.blocks.Length)
        {
            StartCoroutine(FillBlocksPanel());
        }
        else
        {
            Debug.Log("FileDataIncorrect");
        }
    }
    private IEnumerator FillBlocksPanel()
    {
        for (int i = 0; i < levelData.blocks.Length; i++)
        {
            for (int j = 0; j < levelData.counts[i]; j++)
            {
                yield return new WaitForSecondsRealtime(0.05f);

                _blockPool.GrabFromPool(levelData.blocks[i]).transform.SetParent(_blocksPanel.transform);
            }
        }
    }
    
    void Start()
    {
        LoadLevel("level1.1");
    }
}
