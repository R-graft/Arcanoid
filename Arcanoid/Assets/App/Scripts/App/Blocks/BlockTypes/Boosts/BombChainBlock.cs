using System.Collections.Generic;
using System.Linq;

public class BombChainBlock : BoostBlock, IDamageable,IBoostBlock
{    public override void BoostEffect()
    {
        DestroyNeightbours();
    }

    private void DestroyNeightbours()
    {
        var blockNeightboursNames = new Dictionary<string, int>();

        var blockNeightbours = new List<Block>();

        foreach (var item in GridSystem._gridIndexes)
        {
            if (item.Key.x == selfIndex.x + 1 ||  item.Key.x == selfIndex.x - 1 || item.Key.y == selfIndex.y + 1 || item.Key.y == selfIndex.y - 1)
            {
                if (item.Key.x == selfIndex.x || item.Key.y == selfIndex.y)
                {
                    blockNeightbours.Add(item.Value);

                    if (blockNeightboursNames.Keys.Contains(item.Value.name.ToString()))
                    {
                        blockNeightboursNames[item.Value.name.ToString()]++;
                    }
                    else
                    {
                        blockNeightboursNames.Add(item.Value.name.ToString(), 0);
                    }
                }
            }
        }

        var maxEntry = blockNeightboursNames.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

        foreach (var item in blockNeightbours)
        {
            if (item.name == maxEntry && item.GetType() != GetType())
            {
                if (item.TryGetComponent(out IDamageable damage))
                {
                    damage.InDestroy();
                }
            }
        }
    }
}
