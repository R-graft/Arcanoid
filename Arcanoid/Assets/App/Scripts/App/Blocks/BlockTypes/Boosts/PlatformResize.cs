using UnityEngine;

public class PlatformResize : BoostBlock, IDamageable, IBoostBlock
{
    [SerializeField]
    private PlatformResizeBonus _bonusPrefab;

    [SerializeField]
    private float _resizeValue;
    public override void BoostEffect()
    {
        Instantiate(_bonusPrefab, transform.position, Quaternion.identity).resizeValue = _resizeValue;
    }
}
