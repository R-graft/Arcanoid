using UnityEngine;

public class SimpleBlock : Block, IDamageable
{
    [SerializeField]
    private ColoredBlock _coloredBlock;

    [SerializeField]
    public int health;
    public int HealthCount { get => health; set => health = value; }

    public void InDamage(int damageValue)
    {
        HealthCount-= damageValue;

        if (health <= 0)
        {
            InDestroy();
        }

        else
        {
            _coloredBlock.SetColorOnDamage(HealthCount);
        }
    }

    public void InDestroy()
    {
        PoolOnDisable(this);

        Events.blockDestroyed.Invoke(this);
    }
}
