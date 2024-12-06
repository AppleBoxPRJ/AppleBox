using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class interatoreLetto : MonoBehaviour
{
    public bool playerInTrigger;
    public Animator animator;
    public float transitionTime = 1.5f;

    //public int levelIndice;
    // Start is called before the first frame update
    public void Awake()
    {
        playerInTrigger = false;
        Debug.Log(gameHandler.Plevel);
        //levelIndice = gameHandler.Plevel;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ci siamo");
            playerInTrigger = true;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
    // Update is called once per frame
    public void Update()
    {
        
        if (playerInTrigger == true && cassaCollezionista.count != 0)
        {
            if (Input.GetKeyDown("e"))
            {
                PlayerPrefs.SetInt("PlayerLevel", gameHandler.Plevel + 1);
                gameHandler.Plevel = gameHandler.Plevel + 1;
                Debug.Log(gameHandler.Plevel);
                int levelIndice = gameHandler.Plevel;
                //SceneManager.LoadScene("Livello" + gameHandler.Plevel);
                StartCoroutine(loadLevel(levelIndice));
            }
        }

        if (playerInTrigger == true && cassaCollezionista.count == 0)
        {
            if (Input.GetKeyDown("e"))
            {
                SceneManager.LoadScene("Finale_Segreto1");
            }
           
        }
    }

    IEnumerator loadLevel(int levelIndex)
    {
        Debug.Log("startCoroutine");
        animator.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Livello" + levelIndex);

    }
}
