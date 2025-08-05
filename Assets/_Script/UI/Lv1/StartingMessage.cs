using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartingMessage : MonoBehaviour
{
    [SerializeField] private MouseLook mouseLookComponent;
    [SerializeField] private PlayerMovement playerMovementComponent;
    [SerializeField] private PauseMenu pauseMenuComponent;
    
    void OnEnable()
    {
        InputBindings.Instance.InteractAction.performed += Destroy;
    }

    void Start()
    {
        pauseMenuComponent.SetCursorAndMovementEnabled(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Destroy(InputAction.CallbackContext ctx)
    {
        pauseMenuComponent.SetCursorAndMovementEnabled(true);
        Destroy(gameObject);
        InputBindings.Instance.InteractAction.performed -= Destroy;
    }
}
