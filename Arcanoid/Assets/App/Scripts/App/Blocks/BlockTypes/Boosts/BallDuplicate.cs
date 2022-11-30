using UnityEngine;

public class BallDuplicate : BoostBlock, IDamageable, IBoostBlock
{
    public override void BoostEffect()
    {
        DuplicateBall();
    }

    private void DuplicateBall()
    {
        BallsController.OnCreateBall.Invoke(transform.position, true);
    }
}
