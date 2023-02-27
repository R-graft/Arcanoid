using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    [SerializeField]
    private AudioSource _backgroundAudio;

    [SerializeField]
    private AudioSource _buttonAudio;

    private AudioState _audioState;

    [SerializeField]
    private AudioClip _menu;

    [SerializeField]
    private AudioClip _game;

    [SerializeField]
    private AudioClip _pack;

    public void Init()
    {
        SingleInit();

        _audioState = new AudioState();

        if (_audioState.GetAudioValues().music)
            _backgroundAudio.Play();
    }

    public void SetCurrentAudioClip(SCENELIST currentScene)
    {
        if (!_audioState.GetAudioValues().music)
            return;

        switch (currentScene)
        {
            case SCENELIST.StartScene:
                _backgroundAudio.clip = _menu;
                _backgroundAudio.Play();
                break;

            case SCENELIST.PackScene:
                _backgroundAudio.clip = _pack;
                _backgroundAudio.Play();
                break;

            case SCENELIST.GameScene:
                _backgroundAudio.clip = _game;
                _backgroundAudio.Play();
                break;
        }
    }

    public void GetButtonClickSound()
    {
        _buttonAudio.Play();
    }

    public void MusicHandle()
    {
        bool musicValue = _audioState.GetAudioValues().music;

        _audioState.EnableMusic(!musicValue);

        if (musicValue == true)
            _backgroundAudio.Stop();

        else
            _backgroundAudio.Play();
    }

    public void SoundHandler()
    {
        bool soundValue = _audioState.GetAudioValues().sound;

        _audioState.EnableSounds(!soundValue);
    }

    public bool GetMusicValue() => _audioState.GetAudioValues().music;

    public bool GetSoundValue() => _audioState.GetAudioValues().sound;

    private void OnEnable()
    {
        ScenesManager.OnLoadScene += SetCurrentAudioClip;
    }
    private void OnDisable()
    {
        ScenesManager.OnLoadScene -= SetCurrentAudioClip;
    }
}
