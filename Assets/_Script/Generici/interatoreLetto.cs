using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class InteratoreLetto : MonoBehaviour
{
    public bool playerInTrigger;
    public Animator animator;
    public float transitionTime = 1.5f;

    //public int levelIndice;
    // Start is called before the first frame update
    public void Awake()
    {
        playerInTrigger = false;
        Debug.Log(GameHandler.Plevel);
        //levelIndice = GameHandler.Plevel;
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
        
        if (playerInTrigger == true && CassaCollezionista.count != 0)
        {
            if (Input.GetKeyDown("e"))
            {
                PlayerPrefs.SetInt("PlayerLevel", GameHandler.Plevel + 1);
                GameHandler.Plevel = GameHandler.Plevel + 1;
                Debug.Log(GameHandler.Plevel);
                int levelIndice = GameHandler.Plevel;
                //SceneManager.LoadScene("Livello" + GameHandler.Plevel);
                StartCoroutine(loadLevel(levelIndice));
            }
        }

        if (playerInTrigger == true && CassaCollezionista.count == 0 && GameHandler.Plevel <= 2)
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
