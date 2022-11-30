using UnityEngine;

public class PackViewManager : MonoBehaviour
{
    [SerializeField]
    private PackView[] _packViews;

    [SerializeField]
    private PacksData _packsData;

    [SerializeField]
    private RectTransform _content;

    private const int MinEnergyForStart = 3;

    private void Awake()
    {
        SetPacksView();
    }

    public void SetPacksView()
    {
        for (int i = 0; i < _packsData.packsModels.Length; i++)
        {
            _packViews[i].SetInterface(_packsData.packsModels[i]);

            _packViews[i].SetStatus(_packsData.packsModels[i].isOpen);

            if (!_packsData.packsModels[i].isOpen && _packsData.packsModels[i-1].isOpen)
            {
                SetScrollContentPosition(i - 1);
            }
        }
    }
    public void SetPack(int index)
    {
        if (GameProgressController.instance.Energy >= MinEnergyForStart)
        {
            GameProgressController.OnSetPack.Invoke(index);

            ScenesManager.instance.LoadScene(SCENELIST.GameScene);
        }
        else
        {
            return;
        }
    }

    private void SetScrollContentPosition(int index)
    {
        var contentRectHeight = _content.rect.height;

        var heightStep = contentRectHeight / _packViews.Length;

        _content.localPosition += new Vector3(_content.localPosition.x, heightStep * index, _content.localPosition.z);
    }
}
