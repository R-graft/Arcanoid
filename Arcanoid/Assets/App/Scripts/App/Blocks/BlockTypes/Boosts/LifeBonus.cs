public class LifeBonus : Bonus
{
    public bool isLifeUp;

    private const int BonusLivesCount = 1;
    public override void Apply()
    {
        Resize();

        StartTimer();
    }

    public override void Remove()
    {

    }

    private void Resize()
    {
        GameplaySystem.ChangeLives.Invoke(BonusLivesCount, isLifeUp);
    }
}
