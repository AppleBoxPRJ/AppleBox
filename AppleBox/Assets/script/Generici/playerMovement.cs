using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Vector3 velocity;
    public Controls moveAction;
    public Vector2 movementDirection;
    public Transform cameraTransform;
    public Vector3 forward;
    public Vector3 right;
    // Start is called before the first frame update
    void Awake()
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Movements();
    }

    void Movements()
    {        
        forward = cameraTransform.forward;
        right = cameraTransform.right;
        Vector3 move = (forward * movementDirection.y + right * movementDirection.x); //new Vector3(-movementDirection.y, 0, -movementDirection.x) * speed * Time.deltaTime;
        Debug.Log($"Move Input: {movementDirection}");
        controller.Move(move * speed *Time.deltaTime);

        //gestione della gravita'
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //void Old_Movements()
    //{
    //    //get axis to move
    //    float HorizontalInput = Input.GetAxisRaw("Horizontal");
    //    float VerticalInput = Input.GetAxisRaw("Vertical");
    //    Vector3 movement = transform.right * HorizontalInput + transform.forward * VerticalInput;
    //
    //    //actual movement
    //    controller.Move(movement * speed * Time.deltaTime);
    //
    //    //gestione della gravita'
    //    velocity.y += gravity * Time.deltaTime;
    //    controller.Move(velocity * Time.deltaTime);
    //}
}
