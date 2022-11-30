using UnityEngine;
using System.Collections.Generic;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField]
    private BlocksData blocksData;

    [SerializeField]
    private GridSystem _gridSystem;

    public static Dictionary<string, ObjectPool<Block>> _pools;

    public static Dictionary<string, AbstractFactory<Block>> _factories;

    private bool IsInited;

    public void Init()
    {
        if (!IsInited)
        {
            SpawnBlocks();

            IsInited = true;
        }
    }
    private void SpawnBlocks()
	{
        _pools = new Dictionary<string, ObjectPool<Block>>();

        _factories = new Dictionary<string, AbstractFactory<Block>>();

        foreach (var block in blocksData.blocksTypes)
        {
            AbstractFactory<Block> factory = new FactoryBlock<Block>(block, _gridSystem);

            _factories.Add(block.blockId.ToString(), factory);

            ObjectPool<Block> pool = new ObjectPool<Block>(block.PoolOnCreateNewBlock, block => block.PoolOnCreate(block), block => block.PoolOnGet(block));
           
            for (int i = 0; i < block.poolSize; i++)
            {
                var newObject = factory.CreateObject();

                pool.Add(newObject);
            }
            _pools.Add(block.blockId.ToString(), pool);
        }
    }
}
