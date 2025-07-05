using TMPro;
using UnityEngine;
using UniRx;

public class OpenedDoorMessage : MonoBehaviour
{
    [Header("Message")]
    [SerializeField] private CassaCollezionista cassa;
    
    void Start()
    {
        var tmp = GetComponent<TextMeshProUGUI>();
        
        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x >= BuildtimeData.Instance.LevelConfiguration.appleToCollect)
            .First()
            .Subscribe(_ =>
            {
                cassa.OnLookEvt += x => tmp.enabled = x;
            })
            .AddTo(this);   
    }
}
