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
        PlayerPrefs.SetInt("PlayerLevel", GameHandler.Plevel + 1);
        GameHandler.Plevel = GameHandler.Plevel + 1;
        Debug.Log(GameHandler.Plevel);
        int levelIndice = GameHandler.Plevel;
        //SceneManager.LoadScene("Livello" + GameHandler.Plevel);
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
