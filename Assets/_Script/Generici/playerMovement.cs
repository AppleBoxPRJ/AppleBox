using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;
    public float speed = 12f;
    public float gravity = -9.81f;
    
    private Vector3 velocity;
    private Vector2 movementDirection;
    private Vector3 forward;
    private Vector3 right;

    public static Vector3 move;

    void OnEnable()
    {
        InputBindings.Instance.MoveAction.performed += Movements;
        InputBindings.Instance.MoveAction.canceled += Movements;
    }

    void OnDisable()
    {
        InputBindings.Instance.MoveAction.performed -= Movements;
        InputBindings.Instance.MoveAction.canceled -= Movements;
    }

    private void Update()
    {
        forward = cameraTransform.forward;
        right = cameraTransform.right;
        move = (forward * movementDirection.y + right * movementDirection.x);
        
        controller.Move(move * (speed * Time.deltaTime));
        controller.Move(velocity * Time.deltaTime);
    }

    private void Movements(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
        
        //gestione della gravita'
        velocity.y += gravity * Time.deltaTime;
    }
}
