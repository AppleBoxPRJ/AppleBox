using TMPro;
using UnityEngine;

public class CounterPomo : MonoBehaviour
{
    public TextMeshProUGUI textPunteggio;
    public int punteggio;

    private void Update()
    {
        AggiornaPunteggio();
    }

    private void AggiornaPunteggio()
    {
        punteggio = CollectiblesCount.counterOggetti;
        textPunteggio.text = punteggio.ToString();
    }
}
    
