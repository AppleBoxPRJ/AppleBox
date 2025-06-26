using UniRx;
using UnityEngine;

public class CassaCollezionistaLvl2 : MonoBehaviour
{
    public bool playerInTrigger;
    public GameObject text;


    // All'inizio dell'esecuzione nasconde il testo
    void Start()
    {
        playerInTrigger = false;
        text.SetActive(false);
        
        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x == 5)
            .Subscribe(_ => text.gameObject.SetActive(true))
            .AddTo(this);
    }

    void Update()
    {
        if (!playerInTrigger) return;
        
        if (Input.GetKeyDown("e"))
        {
            RuntimeData.Instance.applesInInventoryCount.Value--;
            RuntimeData.Instance.applesDeliveredCount.Value++;
            Debug.Log("metti le cazzo di mele");
        }
    }
    
    // Quando entra il trigger mostra la scritta
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        playerInTrigger = true;
        Debug.Log("ci siamo");
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        playerInTrigger = false;
    }
}
