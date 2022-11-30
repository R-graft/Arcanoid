using UnityEngine;

public class LevelDataLoader : MonoBehaviour
{
    private int _currentLevel;

    public LevelData GetCurrentLevelData()
    {
        if (GameProgressController.instance != null)
        {
            _currentLevel = GameProgressController.instance.Level;

            string _levelsFilesPath = $"/App/Resources/Data/Levels/{_currentLevel}.json";

            return new DataReader<LevelData>(_levelsFilesPath).ReadFile();
        }

        Debug.Log("Game progress not exist");

        return null;
    }
}
