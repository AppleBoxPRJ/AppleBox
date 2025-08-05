using TMPro;
using UnityEngine;

public class MessageShower : MonoBehaviour
{
    [Header("Messages")]
    [SerializeField] private TextMeshProUGUI firstMessage;
    [SerializeField] private TextMeshProUGUI secondMessage;
    
    private OpenDoor _door;
    private Collider _collider;

    void Start()
    {
        _door  = GetComponent<OpenDoor>();
        _collider = GetComponent<Collider>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        firstMessage.enabled = true;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        firstMessage.enabled = false;
        
        if (!(other.transform.position.x > transform.position.x)) return;
        _door.SetDoorMesh(false);
        _collider.enabled = false;
    }
}
 