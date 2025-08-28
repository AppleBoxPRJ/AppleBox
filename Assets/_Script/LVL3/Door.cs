using TMPro;
using UnityEngine;

namespace LevelThree
{
    public class Door : MonoBehaviour
    {
        [Header("Messages")]
        [SerializeField] private TextMeshProUGUI frase;
        //[SerializeField] private TextMeshProUGUI secondMessage;
    
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
        
            frase.gameObject.SetActive(true);
        }
    
        void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            frase.gameObject.SetActive(false);
        
            if (!(other.transform.position.x > transform.position.x)) return;
            _door.SetDoorMesh(false);
            _collider.enabled = false;
        }
    }
}