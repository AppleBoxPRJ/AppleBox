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
        pauseMenuComponent.suca(false);
        //mouseLookComponent.enabled = false;
        //playerMovementComponent.enabled = false;
    }

    private void Destroy(InputAction.CallbackContext ctx)
    {
        pauseMenuComponent.suca(true);
        Destroy(gameObject);
        InputBindings.Instance.InteractAction.performed  -= Destroy;
    }
}
