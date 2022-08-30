using System.Collections.Generic;
using UnityEngine;

public class BlockPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;

        public int healthLevel;

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

                newPoolObject.GetComponent<SimpleBlock>().blockHealth = pool.healthLevel;

                newPoolObject.SetActive(false);

                objectPool.Enqueue(newPoolObject);
            }
            poolsDictionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject GrabFromPool(string tag)
    {
        if (!poolsDictionary.ContainsKey(tag))
        {
            Debug.Log("key not found");

            return null;
        }

        GameObject spawnObject = poolsDictionary[tag].Dequeue();

        spawnObject.SetActive(true);

        poolsDictionary[tag].Enqueue(spawnObject);

        return spawnObject;
    }
}
