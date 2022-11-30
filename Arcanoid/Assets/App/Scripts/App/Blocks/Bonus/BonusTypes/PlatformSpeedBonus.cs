public class PlatformSpeedBonus : Bonus
{
    public bool isSpeedUp;
    public override void Apply()
    {
        Resize();

        StartTimer();
    }

    public override void Remove()
    {
        PlatformController.SetPlatformSpeed.Invoke(!isSpeedUp);
    }

    private void Resize()
    {
        PlatformController.SetPlatformSpeed.Invoke(isSpeedUp);
    }
}
