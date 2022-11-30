public class VerticalBomb : BoostBlock, IDamageable, IBoostBlock
{
    public override void BoostEffect()
    {
        DestroyVerticals();
    }

    private void DestroyVerticals()
    {
        foreach (var item in GridSystem._gridIndexes)
        {
            if (item.Key.y == selfIndex.y)
            {
                if (item.Value.TryGetComponent(out IDamageable damage))
                {
                    damage.InDestroy();
                }
            }
        }
    }
}
