using UnityEngine;

[System.Serializable]
public class PopUp
{
    public PopUp(string panelID, GameObject panelPrefab)
    {
        panelId = panelID;

        panelObject = panelPrefab;
    }

    public string panelId;

    public GameObject panelObject;
}
