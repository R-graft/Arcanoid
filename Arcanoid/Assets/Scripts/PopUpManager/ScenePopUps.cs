using System.Collections.Generic;
using UnityEngine;

public class ScenePopUps : MonoBehaviour
{
    [SerializeField]
    private PopUp[] _panels;

    private List<PopUp> _instancePanels = new List<PopUp>();

    private void Awake()
    {
        
    }
    private void Start()
    {
        foreach (var item in _panels)
        {
            GameObject newPanel = Instantiate(item.panelObject, transform);

            item.panelObject.SetActive(false);

            _instancePanels.Add(new PopUp(item.panelId, newPanel));
        }

        PopUpManager.Instance.SetCurrentScenes(_instancePanels);
    }
}
