using UnityEngine;
using TMPro;

public class Billboard : MonoBehaviour
{
    public Transform playerTransform;
    public TextMeshPro appleText;
    
    void Update()
    {
        // Mantiene il billboard rivolto verso la telecamera
        transform.LookAt(transform.position + playerTransform.rotation * Vector3.forward, playerTransform.rotation * Vector3.up);

        // Aggiorna il testo con il valore di count
        switch (GameHandler.Plevel)
        {
            case 1:
                appleText.text = "x " + RuntimeData.Instance.applesDeliveredCount.Value + " / 5";
                break;
            case 2:
                appleText.text = "x " + RuntimeData.Instance.applesDeliveredCount.Value + " / 8";
                break;
            default:
                Debug.Log("vabbe");
                break;
        }
    }
}
