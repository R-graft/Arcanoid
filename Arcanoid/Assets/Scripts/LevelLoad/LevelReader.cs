using System.IO;
using UnityEngine;

public class LevelReader : MonoBehaviour
{
    [System.Serializable]
    public struct LevelData
    {
        public string[] blocks;

        public int[] counts;
    }
    
    public string ReadFile(string fileName)
    {
        string pathToFile = $"/Resources/Levels/{fileName}.json";

        if (File.Exists(Application.dataPath + pathToFile))
        {
            return File.ReadAllText(Application.dataPath + pathToFile);
        }

        else
        {
            Debug.Log("LevelFileNotFound");

            return "";
        }
    }

    public LevelData GetFileData(string fileData)
    {
        string levelData = ReadFile(fileData);

        return JsonUtility.FromJson<LevelData>(levelData);
    }
}
