using UnityEngine;

public class CollectiblesCount : MonoBehaviour
{
    public static int passaggioDiLivello;
    public static int counterOggetti;

    public void Awake()
    {
        counterOggetti = 0;
        passaggioDiLivello = 0;
    }

    //utilizza la funzione OnCollected creata nel file CollectApple
    private void OnEnable() => CollectApple.OnCollected += OnCollectiblesCollected;
    private void OnDisable() => CollectApple.OnCollected -= OnCollectiblesCollected;
    
    public static void Incrementa()
    {
        counterOggetti++;
        Debug.Log(counterOggetti);
    }

    public static void Decrementa()
    {
        if(counterOggetti == 0) return;
        
        counterOggetti--;
        passaggioDiLivello++;
        Debug.Log(passaggioDiLivello);
    }

    private void OnCollectiblesCollected()
    {
        Incrementa();
    }
}

