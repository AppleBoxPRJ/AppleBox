using UnityEngine;
using UnityEngine.InputSystem;

public class InputBindings : MonoBehaviour
{
    [SerializeField] private InputActionAsset _inputActionAsset;

    public InputAction moveAction;
    public InputAction interactAction;

    void OnEnable()
    {
        moveAction = _inputActionAsset.FindAction("Move");
        interactAction = _inputActionAsset.FindAction("Interact");
        
        _inputActionAsset.Enable();
    }

    void OnDisable()
    {
        _inputActionAsset.Disable();
    }
    
    public static InputBindings Instance { get; private set; }
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}