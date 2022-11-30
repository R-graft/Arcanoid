using System;
using System.Collections.Generic;
using UnityEngine;

public class BallsController : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D _ballPrefab;

	private List<Rigidbody2D> _ballsRbs = new List<Rigidbody2D>();

	public static Action<Vector2, bool> OnCreateBall;

    public static Action<Rigidbody2D> OnDestroyBall;
    public void Init(Vector2 position)
	{
		if (_ballsRbs.Count == 0)
		{
			CreateNewBall(position,false);
		}
	}
	public void CreateNewBall(Vector2 position, bool duplicateVelocity)
	{
		var newBall = Instantiate(_ballPrefab, position, Quaternion.identity);

        if (duplicateVelocity)
        {
            newBall.velocity = _ballsRbs[_ballsRbs.Count - 1].velocity;
        }

        _ballsRbs.Add(newBall);

		GameplaySystem.BallsCounter.Invoke(true);
    }

	private void DestroyBall(Rigidbody2D rb)
	{
		if (_ballsRbs.Contains(rb))
		{
			Destroy(rb.gameObject);

			_ballsRbs.Remove(rb);
        }
	}
	public void StopBallMove()
	{
		foreach (var item in _ballsRbs)
		{
			item.velocity = Vector2.zero;
		}
	}

	public void SetBallsInPosition(Vector2 position)
	{
		foreach (var item in _ballsRbs)
		{
			item.position = position;
		}
	}

	public Rigidbody2D GetRb(int index)
	{
		return _ballsRbs[index];
	}

	private void OnEnable()
	{
		OnCreateBall += CreateNewBall;

		OnDestroyBall += DestroyBall;
	}

	private void OnDisable()
	{
		OnCreateBall -= CreateNewBall;

        OnDestroyBall -= DestroyBall;
    }
}
