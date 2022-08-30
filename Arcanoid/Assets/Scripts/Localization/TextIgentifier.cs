using TMPro;

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
        _textMeshPro.text = LangDictionary[identifier];        
    }
}
