using UnityEngine;
using UnityEngine.InputSystem;

public class InputBindings : Singleton<InputBindings>
{
    [SerializeField] private InputActionAsset _inputActionAsset;

    // Player Actions
    public InputAction MoveAction;
    public InputAction LookAction;
    public InputAction InteractAction;
    
    // UI Actions
    public InputAction SubmitAction;
    public InputAction CancelAction;

    protected override void Awake()
    {
        base.Awake();
        
        MoveAction = _inputActionAsset.FindAction("Move");
        LookAction = _inputActionAsset.FindAction("Look");
        InteractAction = _inputActionAsset.FindAction("Interact");
        
        SubmitAction  = _inputActionAsset.FindAction("Submit");
        CancelAction = _inputActionAsset.FindAction("Cancel");
        
        _inputActionAsset.Enable();
    }

    void OnDisable()
    {
        _inputActionAsset.Disable();
    }
}