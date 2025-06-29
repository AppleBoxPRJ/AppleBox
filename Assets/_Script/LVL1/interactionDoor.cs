using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDoor : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject portaChiusa;
    [SerializeField] private GameObject portaAperta;
    [SerializeField] private Collider secondCollider;
    [Header("Messages")]
    [SerializeField] private TextMeshProUGUI warningText;
    
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
        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x == BuildtimeData.Instance.LevelConfiguration.appleToCollect)
            .Subscribe(_ => ApriPorta())
            .AddTo(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = false;
        warningText.gameObject.SetActive(false);
    }

    private void TryOpenDoor(InputAction.CallbackContext ctx)
    {
        if (!_playerInTrigger) return;
        
        _openingTriesCount++;
        warningText.gameObject.SetActive(true);
            
        if (_openingTriesCount >= 4)
        {
            warningText.gameObject.SetActive(false);
            secondCollider.gameObject.SetActive(true);
            ApriPorta();
        }
    }

    private void ApriPorta()
    {
        portaAperta.SetActive(true);
        portaChiusa.SetActive(false);
        _playerInTrigger = false;
    }
}
