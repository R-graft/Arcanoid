using UnityEngine;

public class LevelAttributes : Singleton<LevelAttributes>
{
    protected static Sprite _currentLevelImage;

    protected static string _currentLevelProgress;

    protected static string _currentPackName;

    private void Awake()
    {
        SingleInit();
    }
    public void SetAtrributes(Sprite imgPath, string progress, string name)
    {
        _currentLevelImage = imgPath;

        _currentLevelProgress = progress;

        _currentPackName = name;
    }
}
