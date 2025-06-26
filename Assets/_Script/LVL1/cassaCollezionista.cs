using UnityEngine;

public class CassaCollezionista : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject portaChiusa;
    [SerializeField] private GameObject portaAperta;
    [SerializeField] private Animator animator;
    
    private bool _playerInTrigger;
    
    private void Start()
    {
        text.SetActive(false);
        _playerInTrigger = false;
        Debug.Log("Livello: " + GameHandler.Plevel);
    }
    
    private void Update()
    {
        if (!_playerInTrigger || RuntimeData.Instance.ApplesInInventoryCount.Value == 0) return;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            RuntimeData.Instance.ApplesInInventoryCount.Value--;
            RuntimeData.Instance.ApplesDeliveredCount.Value++;
            animator.SetTrigger("StartAnimation"); // Avvia l'animazione
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = true;
        text.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = false;
        text.SetActive(false);
    }
}
