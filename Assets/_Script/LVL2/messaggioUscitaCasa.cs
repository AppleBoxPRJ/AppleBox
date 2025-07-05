using UnityEngine;

public class MessaggioUscitaCasa : MonoBehaviour
{
    [SerializeField] private GameObject messaggio;
    [SerializeField] private OpenDoor porta;

    void Start()
    {
        messaggio.SetActive(false);
        porta.SetDoorMesh(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        messaggio.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        messaggio.SetActive(false);
        porta.SetDoorMesh(false);
        
        Destroy(gameObject);
    }
}
