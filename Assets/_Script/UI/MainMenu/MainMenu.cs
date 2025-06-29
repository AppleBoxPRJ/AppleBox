using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        QualitySettings.SetQualityLevel(1);
    }
    
    public void NewGame()
    {
        SceneManager.LoadScene("Livello1");
        PlayerPrefs.SetInt("PlayerLevel", 1);
        GameHandler.Plevel = 1;
    }

    public void Riprendi()
    {
        GameHandler.Plevel = PlayerPrefs.GetInt("PlayerLevel");
        SceneManager.LoadScene("Livello" + GameHandler.Plevel);
    }

    public void EsciDalGioco()
    {
        Application.Quit();
    }
}
