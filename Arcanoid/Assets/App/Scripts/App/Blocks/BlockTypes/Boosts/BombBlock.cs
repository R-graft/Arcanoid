public class BombBlock : BoostBlock, IDamageable, IBoostBlock
{
    public override void BoostEffect()
    {
        DestroyNeightbours();
    }
    private void DestroyNeightbours()
    {
        foreach (var item in GridSystem._gridIndexes)
        {
            if (item.Key.x == selfIndex.x + 1 || item.Key.x == selfIndex.x - 1 || item.Key.x == selfIndex.x)
            {
                if (item.Key.y == selfIndex.y + 1 || item.Key.y == selfIndex.y - 1 || item.Key.y == selfIndex.y)
                {
                    if (item.Value.GetType() != GetType() && item.Value.TryGetComponent(out IDamageable damage))
                    {
                        damage.InDamage(2);
                    }
                }
            }
        }
    }
}

