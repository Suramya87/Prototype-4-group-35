using Project.StateMachine;

public class TurtleFSM : StateMachine
{
	private void Awake()
	{
		State movingUp = new MovingUp(gameObject);
		State movingDown = new MovingDown(gameObject);

		Transition tooFarUp = new TooFarUp(gameObject);
		Transition tooFarDown = new TooFarDown(gameObject);

		_stateTransitions = new()
		{
			{
				movingUp,
				new()
				{
					(tooFarUp, movingDown)
				}
			},
			{
				movingDown,
				new()
				{
					(tooFarDown, movingUp)
				}
			}
		};

		SetState(movingUp);
	}
}
