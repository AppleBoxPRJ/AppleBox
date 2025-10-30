#nullable enable
using System;
using UnityEngine;

namespace lvl4
{
   public class CassaCollezionista : MonoBehaviour, IInteractable, ILookable
   {
       [SerializeField] private Animator? animator;
       [SerializeField] private GameObject? appleCounter;
       [SerializeField] private OpenDoor? door;
   
       public event Action<bool>? OnLookEvt; 
   
       public void Interact()
       {
           if (RuntimeData.Instance.applesInInventoryCount.Value == 0) return;
           
           RuntimeData.Instance.applesInInventoryCount.Value--;
           RuntimeData.Instance.applesDeliveredCount.Value++;
           
           animator?.SetTrigger("StartAnimation");

           if (RuntimeData.Instance.applesDeliveredCount.Value == 6)
           {
               Debug.Log("limbs Delivered");
           }
       }
   
       public void OnLook(bool isLooking)
       {
           appleCounter?.SetActive(isLooking);
           OnLookEvt?.Invoke(isLooking);
       }
   } 
}
