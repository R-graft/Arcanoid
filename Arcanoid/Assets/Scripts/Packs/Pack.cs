using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pack : MonoBehaviour
{
    private enum PackStatus
    {
        LOCKED,
        INPROCESS,
        ENDED
    }

    private PackStatus status;

#region(packInterface)
    private Button _packButton;

    private Image _packBackground;

    [SerializeField]
    private TextMeshProUGUI _packNameText;

    [SerializeField]
    private TextMeshProUGUI _packProgressText;

    [SerializeField]
    private string _packName;

    [SerializeField]
    private int _maxPackLevel;

    [SerializeField]
    private Image _packIcon;

    private Sprite _pathToIcon;
#endregion
    [SerializeField]
    private int _packIndex;

    private int _packLevel = 0;
#region(colors)
    private Color _endedColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);

    private Color _inProcessColor = new Color(0f, 1f, 0f, 1f);

    private Color _lockedColor = new Color(1f, 0f, 0f, 1f);
    #endregion
    private void Awake()
    {
        PackInitialize();
    }
    private void PackInitialize()
    {
        status = PackStatus.LOCKED;

        _packButton = GetComponent<Button>();

        _packBackground = GetComponent<Image>();

        _packNameText.text = _packName;

        _packProgressText.text = $"{_packLevel} / {_maxPackLevel}";

        _pathToIcon = Resources.Load<Sprite>($"Images/{_packName}"); 

        _packIcon.sprite = _pathToIcon;
    }
    public void CheckPackStatus(int openPackIndex)
    {
        if (status == PackStatus.ENDED)
        {
            return;
        }
        else if (_packIndex == openPackIndex)
        {
            status = PackStatus.INPROCESS;
        }
        else if (_packIndex < openPackIndex)
        {
            status = PackStatus.ENDED;
        }
    }

    public void ChangePackProgress(int inProgress)
    {
        if (status == PackStatus.INPROCESS)
        {
            _packProgressText.text = inProgress > _maxPackLevel ? $"{_maxPackLevel} / {_maxPackLevel}" : $"{inProgress} / {_maxPackLevel}";
        }
        else if (status == PackStatus.ENDED)
        {
            _packProgressText.text = $"{_maxPackLevel} / {_maxPackLevel}";
        }
    }

    public void SetPackView()
    {
        switch (status)
        {
            case PackStatus.LOCKED:

                _packButton.interactable = false;
                _packBackground.color = _lockedColor;
                break;

            case PackStatus.INPROCESS:

                _packButton.interactable = true;
                _packBackground.color = _inProcessColor;
                break;

            case PackStatus.ENDED:

                _packButton.interactable = false;
                _packBackground.color = _endedColor;
                break;
        }
    }

    public void SendAttributes()
    {
        if (status == PackStatus.INPROCESS)
        {
            GameProgress.Instance.CurrentPackMaxLevel = _maxPackLevel;

            LevelAttributes.Instance.SetAtrributes(_pathToIcon, _packProgressText.text, _packName);
        }
    }
}
