using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [field: SerializeField] public float MoveSpeed { get; private set; } = 10f;

    private TurtleFSM turtleFSM;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        turtleFSM = GetComponent<TurtleFSM>();
    }

    private void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        // Prevent player from moving the turtle if shelled
        if (turtleFSM != null && turtleFSM.IsShelled()) 
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = moveDirection * MoveSpeed;
    }
}
