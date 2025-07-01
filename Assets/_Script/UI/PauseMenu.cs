using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private MouseLook mouseLookComponent;
    [SerializeField] private PlayerMovement playerMovementComponent;
    
    private bool _isPaused;
    
    

    void OnEnable()
    {
        InputBindings.Instance.CancelAction.performed += OnEscapePressed;
    }

    void Start()
    {
        //OnEscapePressed();
        pauseMenuPanel.SetActive(false);
    }

    private void OnEscapePressed(InputAction.CallbackContext context)
    {
        OnEscapePressed();
    }

    private void OnEscapePressed()
    {
        _isPaused = !_isPaused;
        
        Cursor.lockState = _isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = _isPaused;
        pauseMenuPanel.SetActive(_isPaused);
        
        suca(!_isPaused);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        OnEscapePressed();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void suca(bool merda)
    {
        mouseLookComponent.enabled = merda;
        playerMovementComponent.enabled = merda;
        
    }
}
