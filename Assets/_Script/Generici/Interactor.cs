using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractionSource;
    public float InteractionRange = 3f;

    private void Start()
    {
        InteractionRange = 3f;
    }

    private void Update()
    {
        // Controlla se viene premuto E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Se la condizione viene confermata crea un ray che viaggia in avanti fino al massimo range
            var r = new Ray(InteractionSource.position, InteractionSource.forward);
            
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractionRange))
            {
                //se collide, prova ad interagire con quello con cui ha colliso
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactionObject))
                {
                    interactionObject.Interact();
                }
            }
        }

        if(TestoDaScomparire.playerInTrigger)
        {
            InteractionRange = 0f;
        }
    }
}
