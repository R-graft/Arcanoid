using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager Instance;

    private List<PopUp> _scenePanels;

    private void Awake()
    {
        Instance = this;
    }
    public void SetCurrentScenes(List<PopUp> panels)
    {
        _scenePanels = panels;
    }

    public void ShowHidePanel(string _panelId, bool active)
    {
        PopUp currentPanel = _scenePanels.FirstOrDefault(panel => panel.panelId == _panelId);

        if (currentPanel != null)
        {
            currentPanel.panelObject.SetActive(active);
        }
        else
        {
            Debug.Log("panel in manager not found");
        }
    }
    private void Start()
    {
        ShowHidePanel("ellow", true);
    }
}
