using UnityEngine;

public class CassaCollezionista : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private Animator animator;
    
    private bool _playerInTrigger;
    
    void Start()
    {
        text.SetActive(false);
        _playerInTrigger = false;
        Debug.Log("Livello: " + GameHandler.Plevel);
    }
    
    void Update()
    {
        if (!_playerInTrigger || RuntimeData.Instance.applesInInventoryCount.Value == 0) return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            RuntimeData.Instance.applesInInventoryCount.Value--;
            RuntimeData.Instance.applesDeliveredCount.Value++;
            animator.SetTrigger("StartAnimation"); // Avvia l'animazione
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = true;
        text.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = false;
        text.SetActive(false);
    }
}
