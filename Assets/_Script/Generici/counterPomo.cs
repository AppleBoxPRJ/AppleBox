using TMPro;
using UnityEngine;
using UniRx;

public class CounterPomo : MonoBehaviour
{
    private TextMeshProUGUI _appleCountTMP;

    void Start()
    {
        _appleCountTMP = GetComponent<TextMeshProUGUI>();
        RuntimeData.Instance.applesInInventoryCount.Subscribe(x => _appleCountTMP.text = x.ToString());
    }
}