using System.Linq;
using UnityEngine;

public class PackDataLangSwitcher : MonoBehaviour
{
    [SerializeField]
    private PacksData _packsData;

    [SerializeField]
    private WordList _wordList;

    private void SetPackDataLang(int _langId)
    {
        foreach (var model in _packsData.packsModels)
        {
            model.title = _wordList.words.Where(s => s.key == model.titleId).First().phrases[_langId].phrase;
        }
    }
    private void OnEnable()
    {
        LangSwitcher.OnLangSwitch += SetPackDataLang;
    }
    private void OnDisable()
    {
        LangSwitcher.OnLangSwitch -= SetPackDataLang;
    }
}
