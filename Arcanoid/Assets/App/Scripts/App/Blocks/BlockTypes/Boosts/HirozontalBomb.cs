public class HirozontalBomb : BoostBlock,IDamageable,IBoostBlock
{
    public override void BoostEffect()
    {
        DestroyHorizontals();
    }

    private void DestroyHorizontals()
    {
        foreach (var item in GridSystem._gridIndexes)
        {
            if (item.Key.x == selfIndex.x)
            {
                if (item.Value.TryGetComponent(out IDamageable damage))
                {
                    damage.InDestroy();
                }
            }
        }
    }
}
