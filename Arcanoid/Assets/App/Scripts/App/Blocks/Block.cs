using UnityEngine;

[System.Serializable]
public abstract class Block : MonoBehaviour, IPoolable
{
    public BlocksList blockId;

    public int poolSize;

    [HideInInspector]
    public (int x, int y) selfIndex;

    public void PoolOnGet(Block poolObject)
    {
        poolObject.gameObject.SetActive(true);
    }
    public void PoolOnCreate(Block poolObject)
    {
        poolObject.gameObject.SetActive(false);
    }
    public void PoolOnDisable(Block poolObject)
    {
        SpawnSystem._pools[blockId.ToString()].Add(poolObject);
    }
    public void PoolOnCreateNewBlock()
    {
        Block newBlock = SpawnSystem._factories[blockId.ToString()].CreateObject();

        PoolOnDisable(newBlock);
    }
}
