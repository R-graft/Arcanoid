using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    [SerializeField]
    private GameObject _livesContainer;

    [SerializeField]
    private Image _lifeSprite;

    private int _livesCount = 3;

    private void Awake()
    {
        SetLives(_livesCount);

        Events.loseBall.AddListener(DecrementLives);
    }
    private  void SetLives(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(_lifeSprite, _livesContainer.transform);
        }
    }
    private void DecrementLives()
    {
        _livesCount--;

        if (_livesCount == 0)
        {
            Events.loseLevel.Invoke();

            PopUpManager.Instance.ShowHidePanel("GameOver", true);

            return;
        }

        Destroy(_livesContainer.transform.GetChild(0).gameObject);
    }
    private void IncrementLives()
    {
        SetLives(1);
    }
}
