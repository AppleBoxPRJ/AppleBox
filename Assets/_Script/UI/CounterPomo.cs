using TMPro;
using UnityEngine;
using UniRx;

public class CounterPomo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _appleCountTMP;

    void Start()
    {
        RuntimeData.Instance.applesInInventoryCount.Subscribe(x => _appleCountTMP.text = x.ToString());
    }
}