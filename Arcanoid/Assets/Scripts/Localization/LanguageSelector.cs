using UnityEngine;
using UnityEngine.UI;
using System;

public class LanguageSelector : MonoBehaviour
{
    [SerializeField]
    private LangResolver langResolver;

    [SerializeField]
    private Dropdown selector;

    private Languages _selectedLang;

    private static int _seLectedValue;

    private void Awake()
    {
        selector.onValueChanged.AddListener(delegate { SelectLang(); });

        var langsList = Enum.GetValues(typeof(Languages));

        foreach (var item in langsList)
        {
            selector.options.Add(new Dropdown.OptionData { text = item.ToString() });
        }

        selector.value = _seLectedValue;
    }

    public void SelectLang()
    {
        _selectedLang = (Languages)selector.value;

        langResolver.ChangeLang(_selectedLang);

        _seLectedValue = selector.value;
    }
}
