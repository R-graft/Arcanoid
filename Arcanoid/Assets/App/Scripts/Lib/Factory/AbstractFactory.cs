using UnityEngine;

public abstract class AbstractFactory<T> : MonoBehaviour
{
    public abstract T CreateObject();
}
