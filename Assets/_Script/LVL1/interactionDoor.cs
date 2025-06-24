using UnityEngine;

public class InteractionDoor : MonoBehaviour
{
    public GameObject porta;
    public GameObject porta_aperta;
    public GameObject text;
    //public GameObject text2;
    public GameObject collider2;
    public int counter;
    public bool playerInTrigger;

    public GameObject messaggioIniziale;

    void Start()
    {
        text.SetActive(false);
        //text2.SetActive(false);
        porta.SetActive(true);
        porta_aperta.SetActive(false);
        playerInTrigger = false;
        counter = 0;
        collider2.SetActive(false);
        messaggioIniziale.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            //Time.timeScale = 1f;
            messaggioIniziale.SetActive(false);

        }

        if (playerInTrigger == true && Input.GetKeyDown("e"))
        {
            text.SetActive(true);
            counter++;
            if (counter == 4)
            {
                text.SetActive(false);
                collider2.SetActive(true);
                //text2.SetActive(true);
                ApriPorta();
            }
        }

        if(CassaCollezionista.count == 5)
        {
            ApriPorta();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("diocane");
            playerInTrigger=true;
           
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInTrigger=false;
            text.SetActive(false);
            //text2.SetActive(false);
        }
    }

    private void ApriPorta()
    {
        porta_aperta.SetActive(true);
        porta.SetActive(false);
        playerInTrigger = false;
    }
}
