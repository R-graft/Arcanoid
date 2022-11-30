using System.Collections.Generic;
using UnityEngine;

public class BlocksArranger
{
    private LevelData _levelData;

    public BlocksArranger(LevelData data)
    {
        _levelData = data;
    }
    public void ArrangeBlocks(Dictionary<(int, int), Vector2> gridPositions)
    {
        if (_levelData != null)
        {
            var _indexes = GridSystem._gridIndexes;

            for (int i = 0; i < _levelData.blockTags.Count; i++)
            {
                var spawnedBlock = GetPoolObjects(_levelData.blockTags[i], gridPositions[(_levelData.blockIndexX[i], _levelData.blockIndexY[i])]);

                spawnedBlock.selfIndex = (_levelData.blockIndexX[i], _levelData.blockIndexY[i]);

                _indexes.Add(spawnedBlock.selfIndex, spawnedBlock);
            }
        }
    }

    private Block GetPoolObjects(string tag, Vector2 position)
    {
        var spawnObject = SpawnSystem._pools[tag].Get();

        spawnObject.transform.position = position;

        return spawnObject;
    }
}
