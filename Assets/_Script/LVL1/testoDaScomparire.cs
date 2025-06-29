using UnityEngine;

public class TestoDaScomparire : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject collisore;
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        text.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        text.SetActive(false);
        collisore.SetActive(false);
    }
}