using Project.StateMachine;

public class RabbitFSM : StateMachine
{
	private void Awake()
	{
		State movingLeft = new MovingLeft(gameObject);
		State movingRight = new MovingRight(gameObject);

		Transition tooFarLeft = new TooFarLeft(gameObject);
		Transition tooFarRight = new TooFarRight(gameObject);

		_stateTransitions = new()
		{
			{
				movingLeft,
				new()
				{
					(tooFarLeft, movingRight)
				}
			},
			{
				movingRight,
				new()
				{
					(tooFarRight, movingLeft)
				}
			}
		};

		SetState(movingLeft);
	}
}
