using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class testoDaScomparire : MonoBehaviour
{
    public static bool playerInTrigger;
    public GameObject text;
    public GameObject collisore;
    public GameObject messaggioIniziale;
    public bool pausa = true;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger == true)
        {
            text.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("diocane");
            playerInTrigger = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            text.SetActive(false);
            collisore.SetActive(false);
            //text2.SetActive(false);
        }
    }
}
