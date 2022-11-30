using UnityEngine;

public class BallSpeedBlock : BoostBlock, IDamageable, IBoostBlock
{
    [SerializeField]
    private BallSpeedBonus _bonusPrefab;

    [SerializeField]
    private bool _isSpeedUp;

    public override void BoostEffect()
    {
        Instantiate(_bonusPrefab, transform.position, Quaternion.identity).isSpeedUp = _isSpeedUp;
    }
}
