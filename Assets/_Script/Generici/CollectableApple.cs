using UnityEngine;

public class CollectableApple : MonoBehaviour, IInteractable
{
    public GameObject mela;
   
    public void Interact()
    {
        // Debug.Log("mela raccolta");
        RuntimeData.Instance.applesInInventoryCount.Value++;
        Destroy(mela);
    }
}
