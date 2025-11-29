using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private Vector2 _moveDirection2D;
    [field: SerializeField] public float MoveSpeed { get; private set; } = 10f;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveDirection2D = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        _rigidBody2D.linearVelocity = _moveDirection2D * MoveSpeed;
    }
}
