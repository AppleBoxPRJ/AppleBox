using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteratoreLetto : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private float transitionTime = 1.5f;
    [SerializeField] private GameObject hand;

    private bool _playerInTrigger;
    
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = false;
    }

    public void Interact()
    {
        if (!_playerInTrigger) return;
        
        if (RuntimeData.Instance.applesDeliveredCount.Value != 0 && _playerInTrigger)
        {
                GameHandler.Plevel++;
                PlayerPrefs.SetInt("PlayerLevel", GameHandler.Plevel);
                StartCoroutine(LoadLevel(GameHandler.Plevel));
        }
        else if (RuntimeData.Instance.applesDeliveredCount.Value == 0 && GameHandler.Plevel < 2 && _playerInTrigger)
        {
            SceneManager.LoadScene("Finale_Segreto1");
        }
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        Debug.Log("startCoroutine");
        animator.SetTrigger("start");
        hand.SetActive(false);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Livello" + levelIndex);
    }
}
