using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private List<GameObject> HUDelementsList;
    [Header("Components")]
    [SerializeField] private MouseLook mouseLookComponent;
    [SerializeField] private PlayerMovement playerMovementComponent;
    
    private bool _isPaused;
    
    void OnEnable()
    {
        InputBindings.Instance.CancelAction.performed += OnEscapePressed;
    }

    void Start()
    {
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
        
        pauseMenuPanel.SetActive(_isPaused);
        if (!_isPaused)
            settingsPanel.SetActive(_isPaused);
        
        SetCursorAndMovementEnabled(!_isPaused);
        
    }
    
    public void SetCursorAndMovementEnabled(bool isPaused)
    {
        mouseLookComponent.enabled = isPaused;
        playerMovementComponent.enabled = isPaused;
    }

    
    
    // Logica bottoni
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
}
