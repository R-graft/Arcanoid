using System.Collections.Generic;
using UnityEngine;

public class LangResolver : MonoBehaviour 
{
    protected static Dictionary<string, string> LangDictionary { get; private set; }

    protected static Languages Currentlanguage { get; private set; }

    private void Awake()
    {
        LangDictionary = new Dictionary<string, string>();

        ChangeLang(Currentlanguage);
    }

    private void ReadProperties()
    {
        LangDictionary.Clear();

        TextAsset file = Resources.Load<TextAsset>($"Localization/{Currentlanguage}");

        if (file == null)
        {
            Currentlanguage = Languages.English;

            file = Resources.Load<TextAsset>($"Localization/{Languages.English}");
        }
 
        foreach (var line in file.text.Split('\n'))
        {
            var prop = line.Split('=');

            LangDictionary.Add(prop[0], prop[1]);
        }

        Events.langChanged.Invoke();
    }

    public void ChangeLang(Languages lang)
    {
        Currentlanguage = lang;

        ReadProperties();
    }
}
