using UnityEngine;

public class headBobbingScript : MonoBehaviour
{
    public Animator bobbing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bobbing = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.move.magnitude >= 0.1f)
        {
            startBobbing();
        }else
        {
            stopBobbing();
        }

    }

    public void startBobbing()
    {
        bobbing.SetBool("bobbing", true);
    }

    public void stopBobbing()
    {
        bobbing.SetBool("bobbing", false);
    }
}
