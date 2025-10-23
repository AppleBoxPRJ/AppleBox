using UniRx;

public class RuntimeData : Singleton<RuntimeData>
{
    public ReactiveProperty<int> applesInInventoryCount = new (0);
    public ReactiveProperty<int> applesDeliveredCount = new (0);
    public ReactiveProperty<PauseState> pauseState = new (PauseState.CanPause);
    
    public ReactiveProperty<int> limbsInInventoryCount = new (0);
    public ReactiveProperty<int> limbsDeliveredCount = new (0);
}

public enum PauseState
{
    CanPause,
    CannotPause,
    Paused
}