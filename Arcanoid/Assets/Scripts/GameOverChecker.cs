using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    private int _ballCount = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_ballCount == 1)
        {
            PopUpManager.Instance.ShowHidePanel("GameOver", true);
        }
    }
}
