using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class LangResolver : MonoBehaviour
{
    private Dictionary<string, string> _langDictionary;

    private TextIgentifier[] _allIdentifiers;

    private Dictionary<TextMeshProUGUI, string> _allTexts;

    Languages _currentlanguage;

    void Awake()
    {
        LoadAllTextObjects();
    }
    private void LoadAllTextObjects()
    {
        _langDictionary = new Dictionary<string, string>();

        _allTexts = new Dictionary<TextMeshProUGUI, string>();

        _allIdentifiers = Resources.FindObjectsOfTypeAll<TextIgentifier>();

        foreach (TextIgentifier langText in _allIdentifiers)
        {
            _allTexts.Add(langText.GetComponent<TextMeshProUGUI>(), langText.identifier);
        }
    }

    private void ReadProperties(Languages lang)
    {
        _langDictionary.Clear();

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

            _langDictionary.Add(prop[0], prop[1]);
        }
       
    }
    private void ResolveTexts()
    {
        foreach (var langText in _allTexts)
        {
            langText.Key.text = Regex.Unescape(_langDictionary[langText.Value]);
        }
    }
    public void ChangeLang(Languages lang)
    {
        ReadProperties(lang);

        ResolveTexts();
    }
}
