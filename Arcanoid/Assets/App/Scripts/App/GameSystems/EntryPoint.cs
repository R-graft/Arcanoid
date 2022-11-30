using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private GameProgressController _gameProgress;

    [SerializeField]
    private ScenesManager _scenesManager;

    private void Awake()
    {
        _gameProgress.Init();

        _scenesManager.Init();
    }
}
