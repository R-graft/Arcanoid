using System;
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

    private int _currentPack;

    private int _currentLevel;

    private int _currentBlocksCount;

    public static Action<int> onBlocksCreated;

    private void Awake()
    {
        _levelReader = new LevelReader();

         GetProgress();
    }

    private void GetProgress()
    {
        if (GameProgress.Instance != null)
        {
            _currentPack = GameProgress.Instance.OpenPackIndex;

            _currentLevel = GameProgress.Instance.PackLevel;
        }
        else
        {
            Debug.Log("Game progress not exist");

            _currentPack = 0;

            _currentLevel = 0;
        }
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

                _currentBlocksCount++;
            }
        }
        yield return new WaitForSecondsRealtime(0.05f);

        SendBlocksCount();
    }
    
    private void SendBlocksCount()
    {
        onBlocksCreated.Invoke(_currentBlocksCount);

        _currentBlocksCount = 0;
    }
    void Start()
    {
        LoadLevel($"{_currentPack}{_currentLevel}");
    }
}
