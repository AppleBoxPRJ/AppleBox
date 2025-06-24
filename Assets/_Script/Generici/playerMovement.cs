using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Vector3 velocity;
    public Vector2 movementDirection;
    public Transform cameraTransform;
    public Vector3 forward;
    public Vector3 right;

    public static Vector3 move;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Movements();
    }

    private void Movements()
    {        
        forward = cameraTransform.forward;
        right = cameraTransform.right;
        move = (forward * movementDirection.y + right * movementDirection.x); //new Vector3(-movementDirection.y, 0, -movementDirection.x) * speed * Time.deltaTime;
        //Debug.Log($"Move Input: {movementDirection}");
        controller.Move(move * (speed * Time.deltaTime));

        //gestione della gravita'
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
