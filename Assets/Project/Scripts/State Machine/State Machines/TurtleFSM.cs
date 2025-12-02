using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TurtleFSM : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 2f;

    [Header("Shell Settings")]
    [SerializeField] private Sprite shellSprite;
    [SerializeField] private KeyCode toggleKey = KeyCode.E;

    [Header("Shell Damage Settings")]
    [SerializeField] private float damageOnCollision = 5f; // damage to breakables on impact

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.up;
    private bool isShelled = false;
    private Sprite normalSprite;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        normalSprite = sr.sprite;

        rb.bodyType = RigidbodyType2D.Dynamic; 
    }

    private void Update()
    {
        if (GetComponent<BasicMovement>()?.enabled == true && Input.GetKeyDown(toggleKey))
        {
            if (isShelled)
                ExitShell();
            else
                EnterShell();
        }
    }

    private void FixedUpdate()
    {
        if (!isShelled)
        {
            rb.linearVelocity = moveDirection * moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isShelled)
        {
            moveDirection = -moveDirection; 
        }
        else
        {
            BreakableObject breakable = collision.gameObject.GetComponent<BreakableObject>();
            if (breakable != null)
            {
                float collisionForce = collision.relativeVelocity.magnitude;
                float appliedDamage = damageOnCollision * collisionForce;
                breakable.ApplyDamage(appliedDamage);
            }
        }
    }

    public void EnterShell()
    {
        if (isShelled) return;

        isShelled = true;
        rb.linearVelocity = Vector2.zero;
        sr.sprite = shellSprite;
    }

    public void ExitShell()
    {
        if (!isShelled) return;

        isShelled = false;
        rb.linearVelocity = moveDirection * moveSpeed;
        sr.sprite = normalSprite;
    }

    public void Kick(Vector2 direction, float force)
    {
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }

    public bool IsShelled() => isShelled;
}
 