using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteratoreLetto : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float transitionTime = 1.5f;

    private bool _playerInTrigger;

    void OnEnable()
    {
        InputBindings.Instance.InteractAction.performed += OnGoToBed;
    }
    
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

    private void OnGoToBed(InputAction.CallbackContext context)
    {
        if (!_playerInTrigger) return;
    
        if (RuntimeData.Instance.applesDeliveredCount.Value != 0)
        {
                GameHandler.Plevel++;
                PlayerPrefs.SetInt("PlayerLevel", GameHandler.Plevel);
                StartCoroutine(LoadLevel(GameHandler.Plevel));
        }
        else if (RuntimeData.Instance.applesDeliveredCount.Value == 0 && GameHandler.Plevel <= 2)
        {
                SceneManager.LoadScene("Finale_Segreto1");
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
