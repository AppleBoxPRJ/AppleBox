using UnityEngine;
using TMPro;

public class Billboard : MonoBehaviour
{
    public Transform playerTransform;
    public TextMeshPro appleText; // Componente TextMeshPro per visualizzare il testo

    void Start()
    {
        
    }

    void Update()
    {
        // Mantiene il billboard rivolto verso la telecamera
        transform.LookAt(transform.position + playerTransform.rotation * Vector3.forward, playerTransform.rotation * Vector3.up);

        // Aggiorna il testo con il valore di count
        appleText.text = "x " + cassaCollezionista.count + " / 5";
    }
}
