using TMPro;
using UniRx;
using UnityEngine;

public class InteractionDoor : MonoBehaviour
{
    [SerializeField] private GameObject portaChiusa;
    [SerializeField] private GameObject portaAperta;
    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private Collider secondCollider;
    [SerializeField] private GameObject startingMessage;
    
    private bool _playerInTrigger;
    private int _openingTriesCount;
    
    void Start()
    {
        warningText.gameObject.SetActive(false);
        
        portaChiusa.SetActive(true);
        portaAperta.SetActive(false);

        secondCollider.gameObject.SetActive(false);
        startingMessage.SetActive(true);

        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x == 5)
            .Subscribe(_ => ApriPorta())
            .AddTo(this);
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
            startingMessage.SetActive(false);

        if (_playerInTrigger && Input.GetKeyDown("e"))
        {
            warningText.gameObject.SetActive(true);
            _openingTriesCount++;
            
            if (_openingTriesCount == 4)
            {
                warningText.gameObject.SetActive(false);
                secondCollider.gameObject.SetActive(true);
                ApriPorta();
            }
        }
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

    private void ApriPorta()
    {
        portaAperta.SetActive(true);
        portaChiusa.SetActive(false);
        _playerInTrigger = false;
    }
}
