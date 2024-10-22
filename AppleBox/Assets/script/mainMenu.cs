using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame()
    {
        SceneManager.LoadScene("Livello1");
    }

    public void riprendi()
    {
        //devo ricordarmi come si fa
    }

    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void esciDalGioco()
    {
        Application.Quit();
    }
}
