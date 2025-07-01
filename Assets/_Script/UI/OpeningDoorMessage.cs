using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class OpeningDoorMessage : MonoBehaviour
{
    [SerializeField] private new Collider collider;

    private TextMeshProUGUI _tmp;
    
    void Start()
    {
        _tmp = GetComponent<TextMeshProUGUI>();

        var onTriggerEnterAsObservable = collider.OnTriggerEnterAsObservable()
            .Where(coll => coll.gameObject.CompareTag("Player"))
            .Select(_ => true);
        
        var onTriggerExitAsObservable = collider.OnTriggerExitAsObservable()
            .Where(coll => coll.gameObject.CompareTag("Player"))
            .Select(_ => false);

        var onTriggerJoint = onTriggerEnterAsObservable
            .Merge(onTriggerExitAsObservable);
        
        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x >= BuildtimeData.Instance.LevelConfiguration.appleToCollect)
            .First()
            .Subscribe(_ =>
            {
                onTriggerJoint.Subscribe(SetEnable)
                    .AddTo(this);
            })
            .AddTo(this);
    }

    private void SetEnable(bool enable)
    {
        _tmp.enabled = enable;
    }
}
