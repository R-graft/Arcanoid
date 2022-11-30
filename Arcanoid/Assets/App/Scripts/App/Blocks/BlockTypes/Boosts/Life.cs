using UnityEngine;

public class Life : BoostBlock, IBoostBlock, IDamageable
{
    [SerializeField]
    private LifeBonus _bonusPrefab;

    [SerializeField]
    private bool _islifeUp;

    public override void BoostEffect()
    {
        Instantiate(_bonusPrefab, transform.position, Quaternion.identity).isLifeUp = _islifeUp;
    }
}
