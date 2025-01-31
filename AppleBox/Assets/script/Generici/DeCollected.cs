using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeCollecteds : MonoBehaviour
{
    //public static int passaggioDiLivello;
    public void Awake()
    {

    }

    void OnEnable()
    {
        //Debug.Log("xxx");
        cassaCollezionista.DeCollected += siMaAncheMeno;
    }
    void OnDisable() => cassaCollezionista.DeCollected -= siMaAncheMeno;

    void siMaAncheMeno()
    {
        collectiblesCount.Decrementa();
    }
}
