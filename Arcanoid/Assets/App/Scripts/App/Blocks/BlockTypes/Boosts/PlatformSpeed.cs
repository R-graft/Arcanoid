using UnityEngine;
public class PlatformSpeed : BoostBlock, IBoostBlock, IDamageable
{
    [SerializeField]
    private PlatformSpeedBonus _bonusPrefab;

    [SerializeField]
    private bool _isSpeedUp;
    public override void BoostEffect()
    {
        Instantiate(_bonusPrefab, transform.position, Quaternion.identity).isSpeedUp = _isSpeedUp;
    }
}
