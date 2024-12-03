using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public GameObject billboard;
    public GameObject cassaTrigger;

    void Start()
    {
        billboard.SetActive(false);

        if (cassaTrigger.GetComponent<Collider>() == null)
        {
            cassaTrigger.AddComponent<BoxCollider>().isTrigger = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            Debug.Log("CharacterController è entrato nel trigger");
            billboard.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            Debug.Log("CharacterController è uscito dal trigger");
            billboard.SetActive(false);
        }
    }
}
