using DG.Tweening;
using System;
using UnityEngine;

public static class TweenTest 
{
    public static Tweener AnimateMoveX(GameObject animatedObject, float target, float duration, Action completeAction) =>
         animatedObject.transform.DOMoveX(target, duration).SetEase(Ease.Linear).OnComplete(() => completeAction.Invoke());

    public static Tweener AnimateScale(GameObject animatedObject, (float x, float y) vector, float duration, Action completeAction) =>
         animatedObject.transform.DOScale(new Vector2(vector.x, vector.y), duration).SetEase(Ease.Linear).OnComplete(() => completeAction.Invoke());

    public static Sequence SetSequence(int loops, Action callback, params Tweener[] tweeners)
    {
        var sequence = DOTween.Sequence();

        foreach (var item in tweeners)
            sequence.Append(item);

        if (callback != null)
            sequence.AppendCallback(() => callback.Invoke());


        sequence.SetLoops(loops);

        sequence.SetEase(Ease.Linear);

        return sequence;
    }
}
