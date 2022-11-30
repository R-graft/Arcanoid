using UnityEngine;
public class MashineGun : BoostBlock, IBoostBlock, IDamageable
{
    [SerializeField]
    private MashineGunBonus _bonusPrefab;

    public override void BoostEffect()
    {
        Instantiate(_bonusPrefab, transform.position, Quaternion.identity);
    }    
}
