using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    [SerializeField]
    private Collider2D _downCollider;

    private int _ballCount;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_ballCount == 1)
        {

        }
    }
    void Update()
    {
        
    }
}
