using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 10f; // change to property later
	private Rigidbody2D _rigidBody2D;
	private Vector2 _moveDirection2D;

	void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

	private void Update()
	{
		_moveDirection2D = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	private void FixedUpdate()
    {
		_rigidBody2D.linearVelocity = _moveDirection2D * moveSpeed;
	}
}
