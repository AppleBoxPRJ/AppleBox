using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkIntoTheUnknown : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        Debug.Log("Hai scelto la strada che non ti condurr� da nessuna parte");
        SceneManager.LoadScene("Finale_Segreto2");
    }
}
