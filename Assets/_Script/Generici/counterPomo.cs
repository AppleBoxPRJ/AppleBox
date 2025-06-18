using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class counterPomo : MonoBehaviour
{
    public collectiblesCount counterOggetti;
    public TextMeshProUGUI textPunteggio;
    public int punteggio;
    void Update()
    {
        AggiornaPunteggio();
    }

    public void AggiornaPunteggio()
    {
        punteggio = collectiblesCount.counterOggetti;
        textPunteggio.text = punteggio.ToString();
    }
}
    
