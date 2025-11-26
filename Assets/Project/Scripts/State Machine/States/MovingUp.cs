using Project.StateMachine;
using UnityEngine;

public class MovingUp : State
{
	private readonly Rigidbody2D _rigidBody2D;
	private readonly float _moveSpeed;

	public MovingUp(GameObject owner) : base(owner)
	{
		_rigidBody2D = owner.GetComponent<Rigidbody2D>();
		_moveSpeed = owner.GetComponent<PlayerMovementController>().moveSpeed;
	}

	public override void OnEnter() { }
	public override void OnExit() { }

	public override void OnUpdate()
	{
		_rigidBody2D.linearVelocity = _moveSpeed * Vector2.up; // create OnFixedUpdate() later
	}
}
