using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RabbitFSM : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.right;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic; // always dynamic for collisions
    }

    private void OnEnable()
    {
        // Ensure AI starts moving when enabled
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    private void FixedUpdate()
    {
        // Only move via AI when this script is enabled
        if (!enabled) return;

        rb.linearVelocity = moveDirection * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reverse direction when hitting walls
        moveDirection = -moveDirection;
    }
}
