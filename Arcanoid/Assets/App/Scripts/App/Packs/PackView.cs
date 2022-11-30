using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PackView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _packTitle;

    [SerializeField]
    private Image _packIcon;

    [SerializeField]
    private Sprite _closedPackIcon;

    [SerializeField]
    private Image _packBackground;

    [SerializeField]
    private Button _packButton;

    [SerializeField]
    private TextMeshProUGUI _currentLevel;

    [SerializeField]
    private TextMeshProUGUI _maxLevel;

    [SerializeField]
    private int _packIndex;

    public void SetInterface(Pack pack)
    {
        _packTitle.text = pack.title;

        _packIcon.sprite = pack.isOpen ? pack.sprite : _closedPackIcon;

        _currentLevel.text = pack.EndedLevel.ToString();

        _maxLevel.text = (pack.finishLevel - pack.startLevel + 1).ToString();
    }

    public void SetStatus(bool isOpen)
    {
        _packButton.interactable = isOpen;

        _packBackground.color = isOpen ? Color.green : Color.red;
    }
}
