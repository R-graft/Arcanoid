using UnityEngine;

public class BoostBlock : Block
{
    [SerializeField]
    private int health;

    public int HealthCount { get => health; set => health = value; }

    public void InDamage(int damageValue)
    {
        HealthCount -= damageValue;

        if (HealthCount <= 0)
        {
            InDestroy();
        }

        else
        {
           BoostEffect();
        }
    }

    public void InDestroy()
    {
        BoostEffect();

        PoolOnDisable(this);

        Events.blockDestroyed.Invoke(this);
    }

    public virtual void BoostEffect()
    { 
    }
}
