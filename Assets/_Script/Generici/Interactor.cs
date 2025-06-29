using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractionSource;
    
    private float _interactionRange = 3f;

    private void OnEnable()
    {
        InputBindings.Instance.InteractAction.performed += ShootRaycast;
    }

    // void Update()
    // {
    //     if(TestoDaScomparire.playerInTrigger)
    //     {
    //         _interactionRange = 0f;
    //     }
    // }

    private void ShootRaycast(InputAction.CallbackContext ctx)
    {
        // Crea un ray che viaggia in avanti fino al massimo range
        var r = new Ray(InteractionSource.position, InteractionSource.forward);
            
        if (Physics.Raycast(r, out RaycastHit hitInfo, _interactionRange))
        {
            // Se collide, prova ad interagire con quello con cui ha colliso
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactionObject))
            {
                interactionObject.Interact();
            }
        }
    }
}
