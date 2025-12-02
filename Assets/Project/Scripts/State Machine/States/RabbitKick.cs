using UnityEngine;

[RequireComponent(typeof(BasicMovement))]
public class RabbitKick : MonoBehaviour
{
    [Header("Kick Settings")]
    [SerializeField] private float kickForce = 10f;
    [SerializeField] private float kickRange = 1.5f;
    [SerializeField] private KeyCode kickKey = KeyCode.E;

    private BasicMovement playerControl;

    private void Awake()
    {
        playerControl = GetComponent<BasicMovement>();
    }

    private void Update()
    {
        // Only allow kicking while possessed
        if (playerControl != null && !playerControl.enabled) return;

        if (Input.GetKeyDown(kickKey))
        {
            TryKick();
        }
    }

    private void TryKick()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, kickRange);

        foreach (var hit in hits)
        {
            TurtleFSM turtle = hit.GetComponent<TurtleFSM>();
            if (turtle != null && turtle.IsShelled())
            {
                Vector2 kickDir = (turtle.transform.position - transform.position).normalized;
                turtle.Kick(kickDir, kickForce);
                Debug.Log("Rabbit kicked turtle!");
                break; // only kick one turtle per press
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, kickRange);
    }
}
