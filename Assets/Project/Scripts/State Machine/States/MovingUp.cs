using Project.StateMachine;
using UnityEngine;

public class MovingUp : State
{
    private readonly Rigidbody2D _rigidBody2D;
    private readonly float _moveSpeed;

    public MovingUp(GameObject owner) : base(owner)
    {
        _rigidBody2D = owner.GetComponent<Rigidbody2D>();
        _moveSpeed = owner.GetComponent<BasicMovement>().MoveSpeed;
    }

    public override void OnFixedUpdate()
    {
        _rigidBody2D.linearVelocity = _moveSpeed * Vector2.up;
    }
}
