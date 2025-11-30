using UnityEngine;
using Project.StateMachine;

public class TurtleFSM : StateMachine
{
	private void Awake()
	{
		State movingUp = new MovingInDirection(gameObject, Vector2.up);
		State movingDown = new MovingInDirection(gameObject, Vector2.down);

		Transition collidingWithWallUp = new CollidingWithWallInDirection(gameObject, Vector2.up);
		Transition collidingWithWallDown = new CollidingWithWallInDirection(gameObject, Vector2.down);

		_stateTransitions = new()
		{
			{
				movingUp,
				new()
				{
					(collidingWithWallUp, movingDown)
				}
			},
			{
				movingDown,
				new()
				{
					(collidingWithWallDown, movingUp)
				}
			}
		};

		SetState(movingUp);
	}
}
