using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractionSource;
    public float InteractionRange = 3f;

    private void OnEnable()
    {
        InputBindings.Instance.InteractAction.performed += ShootRaycast;
    }

    void Start()
    {
        InteractionRange = 3f;
    }

    void Update()
    {
        if(TestoDaScomparire.playerInTrigger)
        {
            InteractionRange = 0f;
        }
    }

    private void ShootRaycast(InputAction.CallbackContext ctx)
    {
        // Crea un ray che viaggia in avanti fino al massimo range
        var r = new Ray(InteractionSource.position, InteractionSource.forward);
            
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractionRange))
        {
            // Se collide, prova ad interagire con quello con cui ha colliso
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactionObject))
            {
                interactionObject.Interact();
            }
        }
    }
}
