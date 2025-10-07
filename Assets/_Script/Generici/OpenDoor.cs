using UnityEngine;
using UniRx;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private bool isDoorOpenedAtStart;
    
    [Header("Meshes")]
    [SerializeField] private GameObject portaChiusa;
    [SerializeField] private GameObject portaAperta;
    
    private Collider _collider;
    
    void Start()
    {
        _collider = GetComponent<Collider>();
        
        SetDoorMesh(isDoorOpenedAtStart);
        
        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x == BuildtimeData.Instance.LevelConfiguration.appleToCollect)
            .Subscribe(_ =>
            { 
                SetDoorMesh(true);
                _collider.enabled = false;
            })
            .AddTo(this);
    }
    
    public void SetDoorMesh(bool open)
    {
        if (open)
        {
            AudioManager.Instance.PlaySFX("OpenDoor"); 
        }
        else
        {
            AudioManager.Instance.PlaySFX("CloseDoor");
        }
        portaAperta.SetActive(open);
        portaChiusa.SetActive(!open);
    }
}
