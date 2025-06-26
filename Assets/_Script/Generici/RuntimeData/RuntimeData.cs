using UniRx;
using UnityEngine;

public class RuntimeData : MonoBehaviour
{
    public ReactiveProperty<int> applesInInventoryCount = new (0);
    public ReactiveProperty<int> applesDeliveredCount = new (0);
    
    public static RuntimeData Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
