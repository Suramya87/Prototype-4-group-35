using Project.StateMachine;
using UnityEngine;

public class MovingDown : State
{
	private CharacterController _characterController;
	private float _moveSpeed;

	public MovingDown(GameObject owner) : base(owner)
	{
		_characterController = owner.GetComponent<CharacterController>();
		_moveSpeed = owner.GetComponent<BasicMovement>().movementSpeed;
	}

	public override void OnEnter() { }
	public override void OnExit() { }

	public override void OnUpdate()
	{
		_characterController.Move(_moveSpeed * Time.deltaTime * Vector3.down);
	}
}
