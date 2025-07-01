using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractionSource;
    [SerializeField] private float _interactionRange = 3f;

    [Header("icons")] 
    [SerializeField] private Image _crosshair;
    [SerializeField] private Image _hand;

    private Ray r;

    private void OnEnable()
    {
        InputBindings.Instance.InteractAction.performed += ShootRaycast;
        _hand.gameObject.SetActive(false);
        
    }

    void Update()
    {
        r = new Ray(InteractionSource.position, InteractionSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, _interactionRange) && hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactionObject))
        {
            _hand.gameObject.SetActive(true);
            _crosshair.gameObject.SetActive(false);
        }
        else
        {
            _hand.gameObject.SetActive(false);
            _crosshair.gameObject.SetActive(true);
        }
    }

    private void ShootRaycast(InputAction.CallbackContext ctx)
    {
        // Crea un ray che viaggia in avanti fino al massimo range
            
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
