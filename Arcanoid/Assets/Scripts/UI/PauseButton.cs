using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private bool _paused;

    private void Awake()
    {
        _paused = false;
    }

    public void OnPause()
    {
        if (!_paused)
        {
            PopUpManager.Instance.ShowHidePanel("Pause", true);
            Time.timeScale = 0f;
            _paused = !_paused;
        }
        else
        {
            PopUpManager.Instance.ShowHidePanel("Pause", false);
            Time.timeScale = 1f;
            _paused = !_paused;
        }
    }
}
