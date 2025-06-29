using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneTransitionCall : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.5f;
    
    public void ChangeLevel()
    {
        PlayerPrefs.SetInt("PlayerLevel", GameHandler.Plevel + 1);
        GameHandler.Plevel++;
        Debug.Log(GameHandler.Plevel);
        int levelIndice = GameHandler.Plevel;
        //SceneManager.LoadScene("Livello" + GameHandler.Plevel);
        StartCoroutine(LoadLevel(levelIndice));
    }
    
    IEnumerator LoadLevel(int levelIndex)
    {
        Debug.Log("startCoroutine");
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Livello" + levelIndex);

    }
    
}
