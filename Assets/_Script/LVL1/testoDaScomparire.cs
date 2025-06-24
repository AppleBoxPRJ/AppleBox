using UnityEngine;

public class TestoDaScomparire : MonoBehaviour
{
    public static bool playerInTrigger;
    public GameObject text;
    public GameObject collisore;
    public GameObject messaggioIniziale;
    public bool pausa = true;

    void Start()
    {
        text.SetActive(false);
    }

    void Update()
    {
        text.SetActive(playerInTrigger);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        //Debug.Log("diocane");
        playerInTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        playerInTrigger = false;
        text.SetActive(false);
        collisore.SetActive(false);
        //text2.SetActive(false);
    }
}
