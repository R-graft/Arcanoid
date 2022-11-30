using UnityEngine;

public class FuryBall : BoostBlock, IDamageable, IBoostBlock
{
    [SerializeField]
    private FuryBallBonus _furyBallBonusPrefab;

    public override void BoostEffect()
    {
        Instantiate(_furyBallBonusPrefab, transform.position, Quaternion.identity);
    }
}
