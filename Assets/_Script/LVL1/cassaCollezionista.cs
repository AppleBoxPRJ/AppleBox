using System;
using TMPro;
using UnityEngine;
using UniRx;

public class CassaCollezionista : MonoBehaviour, IInteractable, ILookable
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject appleCounter;
    [SerializeField] private TextMeshProUGUI doorOpenedText;

    private event Action<bool> OnLookEvt; 

    void Start()
    {
        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x >= BuildtimeData.Instance.LevelConfiguration.appleToCollect)
            .First()
            .Subscribe(_ =>
            {
                OnLookEvt += x => doorOpenedText.enabled = x;
            })
            .AddTo(this);
    }

    public void Interact()
    {
        if (RuntimeData.Instance.applesInInventoryCount.Value == 0) return;
        
        RuntimeData.Instance.applesInInventoryCount.Value--;
        RuntimeData.Instance.applesDeliveredCount.Value++;
        
        animator.SetTrigger("StartAnimation");
    }

    public void OnLook(bool isLooking)
    {
        appleCounter.SetActive(isLooking);
        OnLookEvt?.Invoke(isLooking);
    }
}