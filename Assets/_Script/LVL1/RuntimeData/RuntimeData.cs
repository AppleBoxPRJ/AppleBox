using UniRx;
using UnityEngine;

public class RuntimeData : MonoBehaviour
{
    public ReactiveProperty<int> ApplesInInventoryCount = new ();
    public ReactiveProperty<int> ApplesDeliveredCount = new ();
    
    public static RuntimeData Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
