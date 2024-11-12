using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{

    public Transform InteractionSource;
    public float InteractionRange = 3f;
    public int counterMele = 0;
    // Start is called before the first frame update
    void Start()
    {
        InteractionRange = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //controlla se viene premuto E
        if (Input.GetMouseButtonDown(0))
        {
            //se la condizione viene confermata crea un ray che viaggia in avanti fino al massimo range
            Ray r = new Ray(InteractionSource.position, InteractionSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractionRange))
            {
                //se collide, prova ad interagire con quello con cui ha colliso
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactionObject))
                {
                    interactionObject.Interact();
                    counterMele++;
                }
            }
        }

        if(testoDaScomparire.playerInTrigger == true)
        {
            InteractionRange = 0f;
        }
    }
}
