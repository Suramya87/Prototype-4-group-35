using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [Header("Breakable Settings")]
    [SerializeField] private float maxHealth = 10f;
    private float currentHealth;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Break();
        }
    }

    private void Break()
    {

        Destroy(gameObject);
    }
}
