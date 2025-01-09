using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneTransitionCall : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.5f;
    
    public void changeLevel()
    {
        PlayerPrefs.SetInt("PlayerLevel", gameHandler.Plevel + 1);
        gameHandler.Plevel = gameHandler.Plevel + 1;
        Debug.Log(gameHandler.Plevel);
        int levelIndice = gameHandler.Plevel;
        //SceneManager.LoadScene("Livello" + gameHandler.Plevel);
        StartCoroutine(loadLevel(levelIndice));
    }
    
    IEnumerator loadLevel(int levelIndex)
    {
        Debug.Log("startCoroutine");
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Livello" + levelIndex);

    }
    
}
