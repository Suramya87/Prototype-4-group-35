using Project.StateMachine;
using UnityEngine;

public class MovingLeft : State
{
	private readonly Rigidbody2D _rigidBody2D;
	private readonly float _moveSpeed;

	public MovingLeft(GameObject owner) : base(owner)
	{
		_rigidBody2D = owner.GetComponent<Rigidbody2D>();
		_moveSpeed = owner.GetComponent<PlayerMovementController>().moveSpeed;
	}

	public override void OnEnter() { }
	public override void OnExit() { }

	public override void OnUpdate()
	{
		_rigidBody2D.linearVelocity = _moveSpeed * Vector2.left; // create OnFixedUpdate() later
	}
}
