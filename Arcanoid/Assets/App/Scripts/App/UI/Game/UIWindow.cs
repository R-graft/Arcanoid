using UnityEngine;

[System.Serializable]
public abstract class UIWindow : MonoBehaviour
{
    public virtual void InitWindow()
    {
    }

    public void ShowWindow()
    {
        gameObject.SetActive(true);
    }
    public void HideWindow()
    {
        gameObject.SetActive(false);
    }
}
