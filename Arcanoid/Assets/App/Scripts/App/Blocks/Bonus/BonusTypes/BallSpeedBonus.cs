public class BallSpeedBonus : Bonus
{
    public bool isSpeedUp;
    public override void Apply()
    {
        SwitchBallMode();

        StartTimer();
    }

    public override void Remove()
    {
        BallSpeedController.SwitchSpeed.Invoke(!isSpeedUp);
    }

    private void SwitchBallMode()
    {
        BallSpeedController.SwitchSpeed.Invoke(isSpeedUp);
    }
}
