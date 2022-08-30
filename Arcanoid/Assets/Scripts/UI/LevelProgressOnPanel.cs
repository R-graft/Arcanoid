using UnityEngine;
using UnityEngine.UI;

public class LevelProgressOnPanel : MonoBehaviour
{
    [SerializeField]
    private Slider _levelProgress;

    private float _progressStep;

    private void Awake()
    {
        Events.blockDestroyed.AddListener(ProgressIncrement);
    }
    private void SetLevelProgress(int blocksCount)
    {
        _progressStep = 1 / (float)blocksCount;

        _levelProgress.value = 0;
    }

    private void ProgressIncrement()
    {
        _levelProgress.value += _progressStep;
    }
    private void OnEnable()
    {
        LevelLoader.onBlocksCreated += SetLevelProgress;
    }
    private void OnDisable()
    {
        LevelLoader.onBlocksCreated -= SetLevelProgress;
    }
}
