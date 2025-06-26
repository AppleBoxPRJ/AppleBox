using UnityEngine;

public class CollectApple : MonoBehaviour, IInteractable
{
    public GameObject mela;
   
    public void Interact()
    {
        //Debug.Log("mela raccolta");
        RuntimeData.Instance.ApplesInInventoryCount.Value++;
        Destroy(mela);
    }
}
