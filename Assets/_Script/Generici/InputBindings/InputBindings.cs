using UnityEngine;
using UnityEngine.InputSystem;

public class InputBindings : MonoBehaviour
{
    [SerializeField] private InputActionAsset _inputActionAsset;

    public InputAction MoveAction;
    public InputAction InteractAction;

    void Awake()
    {
        MoveAction = _inputActionAsset.FindAction("Move");
        InteractAction = _inputActionAsset.FindAction("Interact");
        
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