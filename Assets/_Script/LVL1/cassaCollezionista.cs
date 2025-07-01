using UnityEngine;
using UnityEngine.InputSystem;

public class CassaCollezionista : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject appleCounter;
    
    private bool _playerInTrigger;

    private void OnEnable()
    {
        InputBindings.Instance.InteractAction.performed += DepositApple;
    }

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

    private void DepositApple(InputAction.CallbackContext ctx)
    {
        if (!_playerInTrigger || RuntimeData.Instance.applesInInventoryCount.Value == 0) return;
        
        RuntimeData.Instance.applesInInventoryCount.Value--;
        RuntimeData.Instance.applesDeliveredCount.Value++;
        
        animator.SetTrigger("StartAnimation");
    }
}
