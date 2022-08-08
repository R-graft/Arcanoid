using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class LangResolver : MonoBehaviour
{
    private Dictionary <string, string> _currentLang = new Dictionary<string, string> ();

    private TextIgentifier[] _allIdentifiers;

    private Dictionary<TextMeshProUGUI, string> _allTexts;

    #region(languages list)
    private enum Languages
    {
        English,
        Russian,
        Chinece
    }
    #endregion
    private Languages _currentlanguage;

    void Awake()
    {
        _allTexts = new Dictionary<TextMeshProUGUI, string> ();

        LoadAllTextObjects();
    }

    private void Start()
    {
        //ChangeLang(Languages.Russian);
    }
    private void ChangeLang(Languages lang) 
    {
        ReadProperties(lang);

        ResolveTexts();
    } 
    private void ReadProperties(Languages lang)
    {
        _currentlanguage = lang;

        TextAsset file = Resources.Load<TextAsset>($"Localization/{_currentlanguage}");

        if (file == null)
        {
            _currentlanguage = Languages.English;

            file = Resources.Load<TextAsset>($"Localization/{Languages.English}");
        }

        foreach (var line in file.text.Split('\n'))
        {
            var prop = line.Split('=');

            _currentLang.Add(prop[0], prop[1]);
        }
    }
    public void ResolveTexts()
    {
        foreach (var langText in _allTexts)
        {
            langText.Key.text = Regex.Unescape(_currentLang[langText.Value]);
        }
    }
    public void LoadAllTextObjects()
    {
        _allIdentifiers = Resources.FindObjectsOfTypeAll<TextIgentifier>();

        foreach (TextIgentifier langText in _allIdentifiers)
        {
            _allTexts.Add(langText.GetComponent<TextMeshProUGUI>(), langText.identifier);
        }
    }
}
