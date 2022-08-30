using UnityEngine;

public class GameProgress : Singleton<GameProgress> 
{
    public int Energy { get; private set; }

    public int PackLevel { get; private set; }

    public int OpenPackIndex { get; private set; }

    public int CurrentPackMaxLevel { get; set; } 

    private void Awake()
    {
        SingleInit();

        Events.winLevel.AddListener(IncrementProgress);

        Energy = PlayerPrefs.GetInt("energy");

        PackLevel = PlayerPrefs.GetInt("level");

        OpenPackIndex = PlayerPrefs.GetInt("packIndex");
    }
    
    public void SetEnergy(int energyValue, bool isIncrement)
    {
        if (isIncrement)
        {
            Energy += energyValue;

            PlayerPrefs.SetInt("energy", Energy);
        }
        else
        {
            Energy -= energyValue;

            PlayerPrefs.SetInt("energy", Energy);
        }
    }

    public void IncrementProgress()
    {
        PackLevel++;

        if (PackLevel == CurrentPackMaxLevel)
        {
            OpenPackIndex++;

            PlayerPrefs.SetInt("packIndex", OpenPackIndex);

            PackLevel = 0;
        }

        PlayerPrefs.SetInt("level", PackLevel);
    }
    private void ClearProgress()
    {
        PlayerPrefs.DeleteKey("packIndex");

        PlayerPrefs.DeleteKey("level");
    }
}
