using UnityEngine;

public class MessaggioUscitaCasa : MonoBehaviour
{
    public GameObject messaggio;
    public GameObject portaChiusa;

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
        Destroy(gameObject);
        portaChiusa.SetActive(true);
    }
}
