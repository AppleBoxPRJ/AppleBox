using TMPro;
using UnityEngine;

public class MessageShower : MonoBehaviour
{
    [SerializeField] private OpenDoor door;
    [Header("Messages")]
    [SerializeField] private TextMeshProUGUI firstMessage;
    [SerializeField] private TextMeshProUGUI secondMessage;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        firstMessage.enabled = true;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        firstMessage.enabled = false;
    }
}
 