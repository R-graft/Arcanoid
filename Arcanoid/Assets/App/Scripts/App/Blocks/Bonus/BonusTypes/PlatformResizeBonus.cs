using UnityEngine;

public class PlatformResizeBonus : Bonus
{
    public float resizeValue;

    public override void Apply()
    {
        Resize();

        StartTimer();
    }

    public override void Remove()
    {
        PlatformController.ResizePlatform.Invoke(-resizeValue);
    }

    private void Resize()
    {
        PlatformController.ResizePlatform.Invoke(resizeValue);
    }
}
