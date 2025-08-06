using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [Header("Components")]
    [SerializeField] private MouseLook mouseLookComponent;
    [SerializeField] private PlayerMovement playerMovementComponent;
    
    private bool _isPaused;
    
    void OnEnable()
    {
        InputBindings.Instance.CancelAction.performed += OnEscape;
    }

    void Start()
    {
        pauseMenuPanel.SetActive(false);
    }

    private void OnEscape(InputAction.CallbackContext context)
    {
        if (RuntimeData.Instance.pauseState.Value ==  PauseState.CannotPause) return;
        SwitchPauseState();
    }
    
    private void SwitchPauseState()
    {
        _isPaused = !_isPaused;
        
        Cursor.lockState = _isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        RuntimeData.Instance.pauseState.Value = _isPaused ? PauseState.Paused : PauseState.CanPause;
        
        SetCursorAndMovementEnabled(!_isPaused);
        
        pauseMenuPanel.SetActive(_isPaused);
        if (!_isPaused)
            settingsPanel.SetActive(_isPaused);
    }
    
    public void SetCursorAndMovementEnabled(bool isPaused)
    {
        mouseLookComponent.enabled = isPaused;
        playerMovementComponent.enabled = isPaused;
    }
    
    #region ButtonsLogic

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        SwitchPauseState();
    }

    public void Exit()
    {
        Application.Quit();
    }
    
    #endregion
}
