using UnityEngine;
using UnityEngine.UI;
using System;

public class LanguageSelector : MonoBehaviour
{
    [SerializeField]
    private Dropdown selector;

    [SerializeField]
    private LangResolver _resolver;

    private Languages _selectedLang = Languages.English;

    private void Awake()
    {
        selector.ClearOptions();

        var langsList = Enum.GetValues(typeof(Languages));

        foreach (var item in langsList)
        {
            selector.options.Add(new Dropdown.OptionData {text = item.ToString()});
        }
    }

    public void SelectLang()
    {
        _selectedLang = (Languages)selector.value;

        _resolver.ChangeLang(_selectedLang);
    }
}
