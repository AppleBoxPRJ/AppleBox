using UnityEngine;
using TMPro;

public class Billboard : MonoBehaviour
{
    public Transform playerTransform;
    public TextMeshPro appleText; // Componente TextMeshPro per visualizzare il testo
    
    private void Update()
    {
        // Mantiene il billboard rivolto verso la telecamera
        transform.LookAt(transform.position + playerTransform.rotation * Vector3.forward, playerTransform.rotation * Vector3.up);

        // Aggiorna il testo con il valore di count
        
        switch (GameHandler.Plevel)
        {
            case 1:
                appleText.text = "x " + CassaCollezionista.count + " / 5";
                break;
            case 2:
                appleText.text = "x " + CassaCollezionista.count + " / 8";
                break;
            default:
                Debug.Log("vabbe");
                break;
        }
    }
}
