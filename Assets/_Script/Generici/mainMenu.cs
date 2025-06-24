using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Livello1");
        PlayerPrefs.SetInt("PlayerLevel", 1);
        GameHandler.Plevel = 1;
    }

    public void Riprendi()
    {
        PlayerPrefs.GetInt("PlayerLevel");
        SceneManager.LoadScene("Livello" + GameHandler.Plevel);
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void EsciDalGioco()
    {
        Application.Quit();
    }
}
