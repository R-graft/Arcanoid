using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private GameProgressController _gameProgress;

    [SerializeField]
    private ScenesManager _scenesManager;

    [SerializeField]
    private Inputs _inputs;

    [SerializeField]
    private MenuUI _menuUI;

    [SerializeField]
    private AudioController _audio;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        _gameProgress.Init();

         _scenesManager.Init();

        _inputs.Init();

        _menuUI.Init();

        _audio.Init();

        _inputs.TurnOn(true);
    }
}
