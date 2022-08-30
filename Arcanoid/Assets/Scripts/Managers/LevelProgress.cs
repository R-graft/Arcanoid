using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    private ScenesManager _scenesManager;

    [HideInInspector]
    public int _blocksCount;

    private void Awake()
    {
        _scenesManager = gameObject.AddComponent<ScenesManager>();

        Events.blockDestroyed.AddListener(BlockDesroyed);
    }
   
    public void BlockDesroyed()
    {
        _blocksCount--;

        if (_blocksCount == 0)
        {
            Events.winLevel.Invoke();

            _scenesManager.LoadScene(3);
        }
    }

    private void GetBlocksCount(int createdBlocksCount)
    {
        _blocksCount = createdBlocksCount;
    }

    private void OnEnable()
    {
        LevelLoader.onBlocksCreated += GetBlocksCount;
    }
    private void OnDisable()
    {
        LevelLoader.onBlocksCreated -= GetBlocksCount;
    }
}
