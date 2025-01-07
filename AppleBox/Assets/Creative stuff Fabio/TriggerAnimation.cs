using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto che entra nel trigger ha il tag "Player"
        if (other.CompareTag("Player"))
        {
            // Trova il componente Animator sul giocatore
            Animator playerAnimator = other.GetComponent<Animator>();

            // Se l'Animator esiste, attivalo
            if (playerAnimator != null)
            {
                playerAnimator.enabled = true;
            }
            else
            {
                Debug.LogWarning("L'oggetto con tag 'Player' non ha un componente Animator.");
            }
        }
    }
}
