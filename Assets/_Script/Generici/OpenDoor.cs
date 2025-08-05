using UnityEngine;
using UniRx;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject portaChiusa;
    [SerializeField] private GameObject portaAperta;
    
    [SerializeField] private bool doorParam;
    
    private Collider _collider;
    
    void Start()
    {
        _collider = GetComponent<Collider>();
        
        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x == BuildtimeData.Instance.LevelConfiguration.appleToCollect)
            .Subscribe(_ => { SetDoorMesh(doorParam);
                _collider.enabled = false;
            })
            .AddTo(this);
        
        SetDoorMesh(doorParam);
    }
    
    public void SetDoorMesh(bool open)
    {
        portaAperta.SetActive(open);
        portaChiusa.SetActive(!open);
    }
}
