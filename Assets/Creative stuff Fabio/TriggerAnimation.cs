using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 1.5f;
    public Animator playerAnimator;

    public void Awake()
    {
        //playerAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto che entra nel trigger ha il tag "Player"
        if (other.CompareTag("Player"))
        {
            // Trova il componente Animator sul giocatore
            playerAnimator = other.GetComponent<Animator>();

            // Se l'Animator esiste, attivalo
            if (playerAnimator != null)
            {
                playerAnimator.enabled = true;
                //changeLevel();
                //playerAnimator.enabled = false;
            }
            else
            {
                Debug.LogWarning("L'oggetto con tag 'Player' non ha un componente Animator.");
            }
        }
    }

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
        animator.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Livello" + levelIndex);

    }
}
