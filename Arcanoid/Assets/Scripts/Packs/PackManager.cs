using UnityEngine;
using UnityEngine.UI;

public class PackManager : MonoBehaviour
{
    [SerializeField]
    private Pack[] _packs;
   
    private int _openPackIndex;

    private int _packLevel;

    private void Awake()
    {
        UpdatePacks();
    }

    public void UpdatePacks()
    {
        GetCurrentProgress();

        CheckPackStatuses();

        ChangePacksProgress();

        SetPacksView();

        SetAttributes();
    }
    private void GetCurrentProgress()
    {
        if (GameProgress.Instance != null)
        {
            _openPackIndex = GameProgress.Instance.OpenPackIndex;

            _packLevel = GameProgress.Instance.PackLevel;
        }
        else
        {
            _openPackIndex = 0;

            _packLevel = 0;
        }
    }

    private void CheckPackStatuses()
    {
        foreach (var item in _packs)
        {
            item.CheckPackStatus(_openPackIndex);
        }
    }

    private void ChangePacksProgress()
    {
        foreach (var item in _packs)
        {
            item.ChangePackProgress(_packLevel);
        }
    }

    private void SetPacksView()
    {
        foreach (var item in _packs)
        {
            item.SetPackView();
        }
    }

    private void SetAttributes()
    {
        foreach (var item in _packs)
        {
            item.SendAttributes();
        }
    }
}
