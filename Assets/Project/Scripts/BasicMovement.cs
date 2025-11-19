using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BasicMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    // public float rotationSpeed = 200f;
    private CharacterController controller;

    private Vector3 movement;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, y, 0f).normalized;
        controller.Move(movementSpeed * Time.deltaTime * move);
    }
}
