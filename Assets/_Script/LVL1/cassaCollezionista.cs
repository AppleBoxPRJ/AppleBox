using UnityEngine;
using UnityEngine.InputSystem;

public class CassaCollezionista : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject appleCounter;
    
    private bool _playerInTrigger;
    private IInteractable _iInteractableImplementation;
    

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = true;
        appleCounter.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = false;
        appleCounter.SetActive(false);
    }

    public void Interact()
    {
        if (!_playerInTrigger || RuntimeData.Instance.applesInInventoryCount.Value == 0) return;
        
        RuntimeData.Instance.applesInInventoryCount.Value--;
        RuntimeData.Instance.applesDeliveredCount.Value++;
        
        animator.SetTrigger("StartAnimation");
    }
}
