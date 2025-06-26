using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteratoreLetto : MonoBehaviour
{
    public bool playerInTrigger;
    public Animator animator;
    public float transitionTime = 1.5f;

    public void Awake()
    {
        playerInTrigger = false;
        Debug.Log(GameHandler.Plevel);
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

    public void Update()
    {
        if (playerInTrigger && RuntimeData.Instance.ApplesDeliveredCount.Value != 0)
        {
            if (Input.GetKeyDown("e"))
            {
                PlayerPrefs.SetInt("PlayerLevel", GameHandler.Plevel + 1);
                GameHandler.Plevel = GameHandler.Plevel + 1;
                Debug.Log(GameHandler.Plevel);
                int levelIndice = GameHandler.Plevel;
                StartCoroutine(LoadLevel(levelIndice));
            }
        }

        if (playerInTrigger && RuntimeData.Instance.ApplesDeliveredCount.Value == 0 && GameHandler.Plevel <= 2)
        {
            if (Input.GetKeyDown("e"))
            {
                SceneManager.LoadScene("Finale_Segreto1");
            }
        }
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        Debug.Log("startCoroutine");
        animator.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Livello" + levelIndex);
    }
}
