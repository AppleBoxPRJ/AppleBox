using UnityEngine;

public class MessaggioUscitaCasa : MonoBehaviour
{
    [SerializeField] private GameObject messaggio;
    [SerializeField] private GameObject portaChiusa;

    void Start()
    {
        messaggio.SetActive(false);
        portaChiusa.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        messaggio.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        messaggio.SetActive(false);
        portaChiusa.SetActive(true);
        
        Destroy(gameObject);
    }
}
