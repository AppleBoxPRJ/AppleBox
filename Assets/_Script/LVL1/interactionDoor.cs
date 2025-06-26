using UniRx;
using UnityEngine;

public class InteractionDoor : MonoBehaviour
{
    public GameObject porta;
    public GameObject portaAperta;
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
        portaAperta.SetActive(false);
        playerInTrigger = false;
        counter = 0;
        collider2.SetActive(false);
        messaggioIniziale.SetActive(true);

        RuntimeData.Instance.ApplesDeliveredCount
            .Where(x => x == 5)
            .Subscribe(_ => ApriPorta())
            .AddTo(this);
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
            messaggioIniziale.SetActive(false);

        if (playerInTrigger && Input.GetKeyDown("e"))
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
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        playerInTrigger=true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        playerInTrigger=false;
        text.SetActive(false);
        //text2.SetActive(false);
    }

    private void ApriPorta()
    {
        portaAperta.SetActive(true);
        porta.SetActive(false);
        playerInTrigger = false;
    }
}
