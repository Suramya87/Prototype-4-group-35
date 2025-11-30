using UnityEngine;
using Project.StateMachine;

public class RabbitFSM : StateMachine
{
	private void Awake()
	{
		State movingLeft = new MovingInDirection(gameObject, Vector2.left);
		State movingRight = new MovingInDirection(gameObject, Vector2.right);

		Transition collidingWithWallLeft = new CollidingWithWallInDirection(gameObject, Vector2.left);
		Transition collidingWithWallRight = new CollidingWithWallInDirection(gameObject, Vector2.right);

		_stateTransitions = new()
		{
			{
				movingLeft,
				new()
				{
					(collidingWithWallLeft, movingRight)
				}
			},
			{
				movingRight,
				new()
				{
					(collidingWithWallRight, movingLeft)
				}
			}
		};

		SetState(movingLeft);
	}
}
