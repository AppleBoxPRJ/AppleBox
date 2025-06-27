using UnityEngine;
using UnityEngine.InputSystem;

public class InputBindings : MonoBehaviour
{
    [SerializeField] private InputActionAsset _inputActionAsset;

    // Player Actions
    public InputAction MoveAction;
    public InputAction LookAction;
    public InputAction InteractAction;
    
    // UI Actions
    public InputAction SubmitAction;
    public InputAction CancelAction;

    void Awake()
    {
        MoveAction = _inputActionAsset.FindAction("Move");
        LookAction = _inputActionAsset.FindAction("Look");
        InteractAction = _inputActionAsset.FindAction("Interact");
        
        SubmitAction  = _inputActionAsset.FindAction("Submit");
        CancelAction = _inputActionAsset.FindAction("Cancel");
        
        _inputActionAsset.Enable();
        
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void OnDisable()
    {
        _inputActionAsset.Disable();
    }
    
    public static InputBindings Instance { get; private set; }
}