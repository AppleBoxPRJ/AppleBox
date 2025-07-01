using System.Collections;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDoor : MonoBehaviour, IInteractable
{
    [Header("Game Objects")]
    [SerializeField] private GameObject portaChiusa;
    [SerializeField] private GameObject portaAperta;
    [Header("Messages")]
    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private TextMeshProUGUI tomorrowText;
    
    private bool _isPlayerInTrigger;
    private bool _canForceDoor =  true;
    private int _openingTriesCount;
    private Collider _collider;
    

    void Start()
    {
        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x == BuildtimeData.Instance.LevelConfiguration.appleToCollect)
            .Subscribe(_ => OpenDoor())
            .AddTo(this);
        
        _collider = GetComponent<Collider>();
    }

    public void Interact()
    {
        if (!_canForceDoor) return;
        
        _canForceDoor = false;
        _openingTriesCount++;
            
        switch (_openingTriesCount)
        {
            case < 3:
                StartCoroutine(ShowMessage(warningText));
                break;
            case 3:
                StartCoroutine(ShowMessage(tomorrowText));
                OpenDoor();
                break;
        }
    }

    private void OpenDoor()
    {
        portaAperta.SetActive(true);
        portaChiusa.SetActive(false);
        _collider.enabled = false;
    }


    private IEnumerator ShowMessage(TextMeshProUGUI message)
    {
        message.enabled = true;
        yield return new WaitForSeconds(1.5f);
        message.enabled = false;
        _canForceDoor = true;
    }
}
