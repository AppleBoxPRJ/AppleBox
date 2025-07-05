using UnityEngine;
using UniRx;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject portaChiusa;
    [SerializeField] private GameObject portaAperta;
    
    private Collider _collider;
    
    void Start()
    {
        _collider = GetComponent<Collider>();
        
        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x == BuildtimeData.Instance.LevelConfiguration.appleToCollect)
            .Subscribe(_ => SetDoorMesh(true))
            .AddTo(this);
    }
    
    public void SetDoorMesh(bool open)
    {
        portaAperta.SetActive(open);
        portaChiusa.SetActive(!open);
        _collider.enabled = !open;
    }
}
