using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPrefab;
    public GameObject otherCanva;
    bool pause;

    private void Start()
    {
        PausaOff();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausaOn();
        }
    }

    private void PausaOn()
    {
        if (pause != false) return;
        
        Cursor.lockState = CursorLockMode.None;
        pauseMenuPrefab.SetActive(true);
        //otherCanva.SetActive(false);
        pause = true;
        Time.timeScale = 0;
    }

    private void PausaOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //otherCanva.SetActive(true);
        pauseMenuPrefab.SetActive(false);
        pause = false;
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        PausaOff();
    }

    public void Exit()
    {
        Application.Quit();
    }

}
