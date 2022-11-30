using System.Collections;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField]
    protected float time;

    public abstract void Apply();

    public abstract void Remove();

    public void StartTimer()
    {
        StartCoroutine(BonusTimer());
    }

    public void StopAndRemove()
    {
        Remove();

        BonusAttach._activeBonuses.Remove(this);

        Destroy(gameObject);
    }
    private IEnumerator BonusTimer()
    {
        while (time > 0)
        {
            yield return new WaitForFixedUpdate();
            {
                time -= Time.fixedDeltaTime;
            }
        }

        StopAndRemove();
    }
}
