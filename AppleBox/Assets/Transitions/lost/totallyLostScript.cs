using UnityEngine;

public class totallyLostScript : MonoBehaviour
{
    public Animator lost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lost = GetComponent<Animator>();
        lost.SetBool("lost", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onDisable()
    {
        lost.SetBool("lost", false);
    }
}
