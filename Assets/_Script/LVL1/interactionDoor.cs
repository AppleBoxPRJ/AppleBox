using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDoor : MonoBehaviour
{
    [SerializeField] private GameObject portaChiusa;
    [SerializeField] private GameObject portaAperta;
    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private Collider secondCollider;
    [SerializeField] private GameObject startingMessage;
    
    private bool _playerInTrigger;
    private int _openingTriesCount;

    void OnEnable()
    {
        InputBindings.Instance.InteractAction.performed += TryOpenDoor;
    }

    void OnDisable()
    {
        InputBindings.Instance.InteractAction.performed -= TryOpenDoor;
    }

    void Start()
    {
        warningText.gameObject.SetActive(false);
        portaAperta.SetActive(false);
        secondCollider.gameObject.SetActive(false);

        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x == 5)
            .Subscribe(_ => ApriPorta())
            .AddTo(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger=true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger=false;
        warningText.gameObject.SetActive(false);
    }

    private void TryOpenDoor(InputAction.CallbackContext ctx)
    {
        if (_playerInTrigger)
        {
            warningText.gameObject.SetActive(true);
            _openingTriesCount++;
            
            if (_openingTriesCount >= 4)
            {
                warningText.gameObject.SetActive(false);
                secondCollider.gameObject.SetActive(true);
                ApriPorta();
            }
        }
    }

    private void ApriPorta()
    {
        portaAperta.SetActive(true);
        portaChiusa.SetActive(false);
        _playerInTrigger = false;
    }
}
