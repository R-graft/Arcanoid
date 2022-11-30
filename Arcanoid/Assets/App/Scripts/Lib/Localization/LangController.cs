using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TextTranslator
{
    public string key;

    public Text t;

    public TMP_Text tMp;
}

[System.Serializable]
public class LangPhrase
{
    public string langName;

    public string phrase;
}

[System.Serializable]
public class Word
{
    public string key = "";

    public List<LangPhrase> phrases = new List<LangPhrase>();

    public bool hide = true;

    public Word(WordList data)
    {
        for (int i = 0; i < data.languages.Count; i++)
        {
            phrases.Add(new LangPhrase() { langName = data.languages[i], phrase = "" });
        }
    }
    public Word(Word wordKey)
    {
        for (int i = 0; i < wordKey.phrases.Count; i++)
        {
            phrases.Add(wordKey.phrases[i]);
        }
    }
    public Word()
    {
    }
}
public class LangController : MonoBehaviour
{
    public WordList translatesData;

    [SerializeField]
    private List<TextTranslator> _sceneTexts;

    private Dictionary<string, Word> dictionary = new Dictionary<string, Word>();

    private int _currenLang;

    public void Awake()
    {
        _currenLang = PlayerPrefs.GetInt("CurrentLangIndex");

        ChangeLang(_currenLang);
    }

    public void ChangeLang(int langId)
    {
        dictionary = new Dictionary<string, Word>();

        if (translatesData != null)
        {
            foreach (var item in translatesData.words)
            {
                dictionary.Add(item.key, new Word(item));
            }

            ReTranslateText(langId);

            PlayerPrefs.SetInt("CurrentLangIndex", langId);
        }

        else
        {
            Debug.Log("Set Translation Asset!");
        }

    }
    private void ReTranslateText(int langId)
    {
        foreach (var item in _sceneTexts)
        {
            if (item.t != null)
            {
                item.t.text = dictionary[item.key].phrases[langId].phrase;
            }
            else if (item.tMp != null)
            {
                item.tMp.text = dictionary[item.key].phrases[langId].phrase;
            }
        }
    }

    private void OnEnable()
    {
        LangSwitcher.OnLangSwitch += ChangeLang;
    }
    private void OnDisable()
    {
        LangSwitcher.OnLangSwitch -= ChangeLang;
    }
}
