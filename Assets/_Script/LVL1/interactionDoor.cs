using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDoor : MonoBehaviour
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

    void OnEnable()
    {
        InputBindings.Instance.InteractAction.performed += TryOpenDoor;
    }

    void Start()
    {
        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x == BuildtimeData.Instance.LevelConfiguration.appleToCollect)
            .Subscribe(_ => OpenDoor())
            .AddTo(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _isPlayerInTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _isPlayerInTrigger = false;
        _canForceDoor = true;
        
        warningText.enabled = false;
        tomorrowText.enabled = false;
    }

    private void TryOpenDoor(InputAction.CallbackContext ctx)
    {
        if (!_isPlayerInTrigger) return;
        if (!_canForceDoor) return;
        
        _canForceDoor = false;
        _openingTriesCount++;
            
        switch (_openingTriesCount)
        {
            case < 3:
                warningText.enabled = true;
                break;
            case 3:
                tomorrowText.enabled = true;
                OpenDoor();
                break;
        }
    }

    private void OpenDoor()
    {
        portaAperta.SetActive(true);
        portaChiusa.SetActive(false);
    }
}
