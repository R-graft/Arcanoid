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

    private PackStatus status = PackStatus.LOCKED;

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
#endregion
    [SerializeField]
    private int _packIndex;

    private int _packLevel;
#region(colors)
    private Vector4 _endedColor = new Vector4(150, 150, 150, 150);

    private Vector4 _inProcessColor = new Vector4(140, 255, 130, 255);

    private Vector4 _lockedColor = new Vector4(255, 130, 130, 255);
#endregion
    private void Awake()
    {
        _packButton = GetComponent<Button>();

        _packBackground = GetComponent<Image>();

        _packNameText.text = _packName;

        _packProgressText.text = $"{_packLevel} / {_maxPackLevel}";
    }

    private void CheckPackStatus(int openPackIndex)
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
    private void SetPackView()
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
    private void ChangeProgress(int inProgress)
    {
        if (status == PackStatus.INPROCESS)
        {
            _packProgressText.text = $"{inProgress} / {_maxPackLevel}";
        }
    }
}
