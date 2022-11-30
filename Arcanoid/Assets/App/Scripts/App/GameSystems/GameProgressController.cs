using System;
using UnityEngine;

public class GameProgressController : Singleton<GameProgressController> 
{
    [SerializeField]
    private PacksData _packsDataObject;

    private GameProgressData CurrentProgressData;

    private PackDataController _packsController;

    public int Level { get; private set; }

    public int Energy;
    public int PackIndex { get; private set; }

    public static Action<int> OnSetPack;

    public static Action<bool, int> OnSetEnergy;

    public static Action OnPassLevel;

    private const string gameProgessDataFilePath = "/App/Resources/Data/GameProgressData/GameProgress.json";

    private const string savingDataFilePath = "/App/Resources/Data/GameProgressData";

    public void Init()
    {
        SingleInit();

        _packsController = new PackDataController(_packsDataObject.packsModels, PackIndex);

        LoadProgressData();
    }

    public void SetDataFromVeiw(int packIndex)
    {
        Level = _packsController.GetLevelFrowView(packIndex).level;

        PackIndex = _packsController.GetLevelFrowView(packIndex).pack;

        SaveProgressData();
    }

    public void PassLevel()
    {
        Level++;

        PackIndex = _packsController.OnLevelPass(Level);

        SaveProgressData();
    }

    private void LoadProgressData()
    {
        CurrentProgressData = new DataReader<GameProgressData>(gameProgessDataFilePath).ReadFile();

        if (CurrentProgressData == null)
        {
            SetDefaultProgress();

            return;
        }

        Level = CurrentProgressData.currentLevel;

        PackIndex = CurrentProgressData.currentPackIndex;

        Energy = LoadEnergy(CurrentProgressData.currentEnergy, CurrentProgressData.lastData);

        SaveProgressData();
    }

    private void SaveProgressData()
    {
        CurrentProgressData.currentLevel = Level;

        CurrentProgressData.currentEnergy = Energy;

        CurrentProgressData.currentPackIndex = PackIndex;

        CurrentProgressData.lastData = DateTime.Now.ToFileTime();

        DataWriter<GameProgressData> currentWriter =
            new DataWriter<GameProgressData>(savingDataFilePath, CurrentProgressData, gameProgessDataFilePath);

        currentWriter.SaveFile();
    }

    private void SetDefaultProgress()
    {
        CurrentProgressData = new GameProgressData();

        Energy = 10;

        Level = 1;

        PackIndex = _packsController.SetPackDataToDefault();

        SaveProgressData();
    }

    private void SetEnergy(bool isIncrement, int energyValue)
    {
        Energy = isIncrement ? Energy += energyValue : Energy -= energyValue;

        SaveProgressData();
    }

    private int LoadEnergy(int lastEnergyLavue, long lastSavingDate)
    {
        var savingDate = DateTime.FromFileTime(lastSavingDate);

        return lastEnergyLavue += DateTime.Now.Subtract(savingDate).Hours;
    }

    private void OnEnable()
    {
        OnSetEnergy += SetEnergy;
        OnPassLevel += PassLevel;
        OnSetPack += SetDataFromVeiw;
    }

    private void OnDisable()
    {
        OnSetEnergy -= SetEnergy;
        OnPassLevel -= PassLevel;
        OnSetPack -= SetDataFromVeiw;
    }
    private void OnApplicationPause()
    {
#if PLATFORM_ANDROID
        PlayerPrefs.DeleteKey("FirstIn");
#endif
    }
}
