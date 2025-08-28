using System;
using UnityEngine;

public class pomoLVL3 : MonoBehaviour
{
    [SerializeField] GameObject blackScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            blackScreen.SetActive(true);
            TriggerAnimation.GetInstance().changeLevel();
        }
    }
}
