using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public static GameProgress instance;

    public int energy { get; private set; }

    public int packLevel { get; private set; }

    public int openPackIndex { get; private set; }

    private void Awake()
    {
        instance = this;

        energy = PlayerPrefs.GetInt("energy");

        packLevel = PlayerPrefs.GetInt("level");

        openPackIndex = PlayerPrefs.GetInt("packIndex");
    }

    public void SetEnergy(int energyValue, bool isIncrement)
    {
        if (isIncrement)
        {
            energy += energyValue;

            PlayerPrefs.SetInt("energy", energy);
        }
        else
        {
            energy -= energyValue;

            PlayerPrefs.SetInt("energy", energy);
        }
    }

    public void SetLevel(int levelValue)
    {
        packLevel+= levelValue;

        PlayerPrefs.SetInt("level", packLevel);
    }

    public void SetPackIndex(int indexValue)
    {
        openPackIndex += indexValue;

        PlayerPrefs.SetInt("packIndex", openPackIndex);
    }
}
