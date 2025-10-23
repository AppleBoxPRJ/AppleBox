using System;
using UnityEngine;

public class Frullatore : MonoBehaviour, IInteractable, ILookable
{
    [SerializeField] private Animator? animator;
    [SerializeField] private GameObject? appleCounter;
    [SerializeField] private OpenDoor? door;

    public event Action<bool>? OnLookEvt; 

    public void Interact()
    {
        if (RuntimeData.Instance.limbsInInventoryCount.Value == 0) return;
        
        RuntimeData.Instance.limbsInInventoryCount.Value--;
        RuntimeData.Instance.limbsDeliveredCount.Value++;
        
        animator?.SetTrigger("StartAnimation");
    }

    public void OnLook(bool isLooking)
    {
        appleCounter?.SetActive(isLooking);
        OnLookEvt?.Invoke(isLooking);
    }
}
