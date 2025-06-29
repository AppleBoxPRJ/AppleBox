using UniRx;

public class RuntimeData : Singleton<RuntimeData>
{
    public ReactiveProperty<int> applesInInventoryCount = new (0);
    public ReactiveProperty<int> applesDeliveredCount = new (0);
}