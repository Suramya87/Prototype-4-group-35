using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BasicMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    // public float rotationSpeed = 200f;
    private CharacterController controller;

    private Vector3 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(x, y, 0f);
            controller.Move(move * movementSpeed * Time.deltaTime);
        }

}
