using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

interface IInteractable
{
    public void Interact();
}

interface ILookable
{
    public void OnLook(bool isLooking);
}

public class Interactor : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private Transform InteractionSource;
    [SerializeField] private float _interactionRange = 3f;
    [Header("Icons")]
    [SerializeField] private Image _crosshair;
    [SerializeField] private Image _hand;

    private Ray _ray;
    private RaycastHit _hit;
    private IInteractable _interactable;
    private ILookable _lookable;
    
    private bool _isHitting;
    private bool _canLook;
    private bool _canInteract;

    void OnEnable()
    {
        InputBindings.Instance.InteractAction.performed += ShootRaycast;
    }

    void Start()
    {
        _hand.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        _ray = new Ray(InteractionSource.position, InteractionSource.forward);
        _isHitting = Physics.Raycast(_ray, out _hit, _interactionRange);
        
        _canLook = false;
        _canInteract = false;

        if (_isHitting)
        {
            if (_hit.collider.gameObject.TryGetComponent<ILookable>(out var l))
            {
                if (_hit.collider.gameObject == ((MonoBehaviour)l).gameObject)
                {
                    _lookable = l;
                    _canLook = true;
                }
            }

            if (_hit.collider.gameObject.TryGetComponent<IInteractable>(out var i))
            {
                if (_hit.collider.gameObject == ((MonoBehaviour)i).gameObject)
                {
                    _interactable = i;
                    _canInteract = true;
                }
            }
        }

        _lookable?.OnLook(_canLook);
        
        ShowHand(_canInteract);
    }

    private void ShootRaycast(InputAction.CallbackContext ctx)
    {
        if (!_canInteract) return;
        
        _interactable.Interact();
    }

    private void ShowHand(bool show)
    {
        _hand.gameObject.SetActive(show);
        _crosshair.gameObject.SetActive(!show);
    }
}
