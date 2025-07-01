using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static Vector3 move;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    
    private CharacterController _characterController;
    private Transform _characterTransform;
    
    private Vector3 velocity;
    private Vector2 movementDirection;
    private Vector3 forward;
    private Vector3 right;


    void OnEnable()
    {
        InputBindings.Instance.MoveAction.performed += Movements;
        InputBindings.Instance.MoveAction.canceled += Movements;
    }

    void Start()
    {
        _characterController =  GetComponent<CharacterController>();
        _characterTransform =  GetComponent<Transform>();
    }

    void Update()
    {
        forward = _characterTransform.forward;
        right = _characterTransform.right;
        move = forward * movementDirection.y + right * movementDirection.x;
        
        //gestione della gravita'
        velocity.y += gravity * Time.deltaTime;
        
        _characterController.Move(move * (speed * Time.deltaTime));
        _characterController.Move(velocity * Time.deltaTime);
    }

    private void Movements(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }
}
