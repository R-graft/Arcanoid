using UnityEngine;

public class FuryBallBonus : Bonus
{
    public override void Apply()
    {
        SwitchBallMode();

        StartTimer();
    }

    public override void Remove()
    {
        CollisionController.SwitchCollisionMode.Invoke(false); 
    }

    private void SwitchBallMode()
    {
        CollisionController.SwitchCollisionMode.Invoke(true);
    }
}
