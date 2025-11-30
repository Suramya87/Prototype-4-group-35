using UnityEngine;
using Project.StateMachine;

public class MovingInDirection : State
{
	private readonly Rigidbody2D _rigidBody2D;
	private readonly Vector2 _moveDirection2D;
	private readonly float _moveSpeed;

	public MovingInDirection(GameObject owner, Vector2 moveDirection2D) : base(owner)
	{
		_rigidBody2D = owner.GetComponent<Rigidbody2D>();
		_moveDirection2D = moveDirection2D.normalized;
		_moveSpeed = owner.GetComponent<BasicMovement>().MoveSpeed;
	}

	public override void OnFixedUpdate()
	{
		_rigidBody2D.linearVelocity = _moveDirection2D * _moveSpeed;
    }
}
