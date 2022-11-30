public interface IDamageable 
{
    public int HealthCount { get; set; }
    public void InDamage(int damageValue);

    public void InDestroy();
}
