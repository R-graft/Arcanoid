using System.IO;
using UnityEngine;

public class DataWriter<T>
{
    private string _directory;

    private T _dataFile;

    private string _savingFilePath;

    public DataWriter(string directory, T dataFile, string savingFilePath)
    {
        _directory = directory;

        _dataFile = dataFile;

        _savingFilePath = savingFilePath;
    }

    public void SaveFile()
    {
        var savePath = Application.dataPath + _directory;

        if (Directory.Exists(savePath) && _dataFile != null)
        {
            string savingData = JsonUtility.ToJson(_dataFile);

            string saveFilePath = Application.dataPath + _savingFilePath;

            File.WriteAllText(saveFilePath, savingData);
        }
        else
        {
            Debug.Log("Error save file");
        }
    }
}
