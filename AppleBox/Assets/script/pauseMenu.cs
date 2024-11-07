using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPrefab;
    public GameObject otherCanva;
    bool pause;
    public GameObject messaggioIniziale;




        // Start is called before the first frame update
        void Start()
    {
        PausaOff();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("lo leggo");
            PausaOn();
        }

        if (Input.GetKeyDown("e"))
        {
            messaggioIniziale.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    void PausaOn()
    {
        if(pause == false)
        {
            Cursor.lockState = CursorLockMode.None;
            pauseMenuPrefab.SetActive(true);
            otherCanva.SetActive(false);
            pause = true;
            Time.timeScale = 0;
        }
    }

    void PausaOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        otherCanva.SetActive(true);
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
