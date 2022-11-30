using UnityEngine;

public class PackDataController : MonoBehaviour 
{
	private Pack _currentPack;

    private Pack[] _packsModels;

    private const int _defaultLevel = 0;

	public PackDataController(Pack[] packsModels, int currentPackIndex)
	{
		_packsModels = packsModels;

        _currentPack = _packsModels[currentPackIndex];
    }

    public (int level, int pack) GetLevelFrowView(int packIndex)
    {
        if (packIndex >= 0 && packIndex <= _packsModels.Length)
        {
            _currentPack = _packsModels[packIndex];

            if (_currentPack.isEnded)
            {
                _currentPack.EndedLevel = _defaultLevel;

                _currentPack.isEnded = false;

                return (_currentPack.startLevel, _currentPack.packIndex);
            }

            return (_currentPack.EndedLevel + _currentPack.startLevel, _currentPack.packIndex);
        }
        return (_currentPack.EndedLevel, _currentPack.packIndex);
    }

    public int OnLevelPass(int newLevel)
    {
        _currentPack.EndedLevel++;

        if (newLevel > _currentPack.finishLevel)
        {
            _currentPack.isEnded = true;

            _currentPack = _packsModels[_currentPack.packIndex + 1];

            _currentPack.isOpen = true;
        }

        return _currentPack.packIndex;
    }
    public int SetPackDataToDefault()
	{
        _currentPack = _packsModels[0];

        foreach (var item in _packsModels)
        {
            item.EndedLevel = 0;
            item.isOpen = false;
            item.isEnded = false;
        }

        _packsModels[0].isOpen = true;

        _packsModels[0].EndedLevel = _defaultLevel;

        return _currentPack.packIndex;
    }
}
