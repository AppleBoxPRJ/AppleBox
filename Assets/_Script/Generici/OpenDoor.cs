using System;
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
            .Subscribe(_ =>
            {
                SetDoorMesh(true);
                _collider.enabled = false;
            })
            .AddTo(this);
        
        SetDoorMesh(true);
    }
    
    public void SetDoorMesh(bool open)
    {
        portaAperta.SetActive(open);
        portaChiusa.SetActive(!open);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!(other.transform.position.x > transform.position.x)) return;
        
        SetDoorMesh(false);
        _collider.enabled = false;
    }
}
