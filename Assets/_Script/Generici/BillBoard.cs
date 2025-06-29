using UnityEngine;
using TMPro;
using UniRx;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private TextMeshPro appleText;

    void Start()
    {
        RuntimeData.Instance.applesDeliveredCount
            .Subscribe(UpdateText)
            .AddTo(this);
    }
    
    void Update()
    {
        // Mantiene il billboard rivolto verso la telecamera
        transform.LookAt(transform.position + playerTransform.rotation * Vector3.forward, playerTransform.rotation * Vector3.up);
    }

    private void UpdateText(int value)
    {
        appleText.text = "x " + value + " / " + BuildtimeData.Instance.LevelConfiguration.appleToCollect;
    }
}
