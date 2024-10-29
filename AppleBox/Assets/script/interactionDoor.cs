using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionDoor : MonoBehaviour
{
    public GameObject porta;
    public GameObject text;
    public GameObject text2;
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        text2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("diocane");
            text.SetActive(true);
            counter++;
            if(counter == 4)
            {
                text.SetActive(false);
                text2.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            text.SetActive(false);
            text2.SetActive(false);
        }
    }
}
