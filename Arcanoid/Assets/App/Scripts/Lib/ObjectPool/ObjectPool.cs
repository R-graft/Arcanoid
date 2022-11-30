using System;
using System.Collections.Generic;

public class ObjectPool<T> where T : IPoolable
{
    private Queue<T> _objectsQueue;

    private Action<T> onGet;

    private Action<T> onCreate;

    private Action onGetNewObject;

    public ObjectPool(Action onGetNew, Action<T> onCreate, Action<T> onGet)
    {
        _objectsQueue = new Queue<T>();

        this.onGetNewObject = onGetNew;

        this.onGet = onGet;

        this.onCreate = onCreate;
    }

    public void CreatePoolObject()
    {
        onGetNewObject();
    }

    public void Add(T addedObject)
    {
        _objectsQueue.Enqueue(addedObject);

        onCreate(addedObject);
    }
    public T Get()
    {
        if (_objectsQueue.Count == 0)
        {
            CreatePoolObject();
        }

        T spawnObject = _objectsQueue.Dequeue();

        onGet(spawnObject);

        return spawnObject;
    }
}
