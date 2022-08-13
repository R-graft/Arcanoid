using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;

        public GameObject prefab;

        public int poolSize;
    }
    [SerializeField]
    private GameObject _poolContainer;
    public Pool[] pools;

    private Dictionary<string, Queue<GameObject>> poolsDictionary;
    private void Awake()
    {
        CreatePools();
    }
    public void CreatePools()
    {
        poolsDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject newPoolObject = Instantiate(pool.prefab, _poolContainer.transform);

                newPoolObject.SetActive(false);

                objectPool.Enqueue(newPoolObject);
            }
            poolsDictionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject GrabFromPool(string _tag)
    {
        if (!poolsDictionary.ContainsKey(_tag))
        {
            Debug.Log("key not found");

            return null;
        }

        GameObject spawnObject = poolsDictionary[_tag].Dequeue();

        spawnObject.SetActive(true);

        poolsDictionary[_tag].Enqueue(spawnObject);

        return spawnObject;
    }
}
