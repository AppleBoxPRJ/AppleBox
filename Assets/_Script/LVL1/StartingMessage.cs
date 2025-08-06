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
        RuntimeData.Instance.pauseState.Value = PauseState.CannotPause;
    }

    private void Destroy(InputAction.CallbackContext ctx)
    {
        pauseMenuComponent.SetCursorAndMovementEnabled(true);
        RuntimeData.Instance.pauseState.Value = PauseState.CanPause;
        Destroy(gameObject);
        InputBindings.Instance.InteractAction.performed -= Destroy;
    }
}
