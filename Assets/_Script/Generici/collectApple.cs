using System;
using UnityEngine;

public class CollectApple : MonoBehaviour, IInteractable
{
    public static event Action OnCollected;
    public GameObject mela;
   
    public void Interact()
    {
        //Debug.Log("mela raccolta");
        OnCollected?.Invoke();
        Destroy(mela);
    }
}
