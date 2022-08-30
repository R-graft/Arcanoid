using TMPro;
using UnityEngine;

public class TextIgentifier : LangResolver
{
    private TextMeshProUGUI _textMeshPro;

    public string identifier;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();

        ResolveText();

        Events.langChanged.AddListener(ResolveText);
    }
    private void ResolveText()
    {
        if (LangDictionary != null)
        {
            _textMeshPro.text = LangDictionary[identifier];
        }
        else
        {
            Debug.Log("LangResolver not exist");
        }
    }
}
