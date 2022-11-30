public class NonDamageBlock : Block, IDamageable
{
    public int HealthCount { get ; set ; }

    public void InDamage(int damageValue)
    {
        if (damageValue > 1)
        {
            InDestroy();
        }
    }

    public void InDestroy()
    {
        PoolOnDisable(this);

        Events.blockDestroyed.Invoke(this);
    }
}
