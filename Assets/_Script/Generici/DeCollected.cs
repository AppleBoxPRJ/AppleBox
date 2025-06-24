using UnityEngine;

public class DeCollecteds : MonoBehaviour
{
    private void OnEnable() => CassaCollezionista.DeCollected += SiMaAncheMeno;
    private void OnDisable() => CassaCollezionista.DeCollected -= SiMaAncheMeno;

    private void SiMaAncheMeno()
    {
        CollectiblesCount.Decrementa();
    }
}
