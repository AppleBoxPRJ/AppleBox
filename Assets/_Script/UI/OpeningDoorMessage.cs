using UnityEngine;
using UniRx;

public class OpeningDoorMessage : MonoBehaviour
{
    void Start()
    {
        RuntimeData.Instance.applesDeliveredCount
            .Where(x => x >= 5)
            .Subscribe(_ => gameObject.SetActive(true))
            .AddTo(this);
    }
}
