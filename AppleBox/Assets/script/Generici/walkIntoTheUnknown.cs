using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class walkIntoTheUnknown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("hai scelto la strada che non ti condurr� da nessuna parte");
            SceneManager.LoadScene("Finale_Segreto2");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
