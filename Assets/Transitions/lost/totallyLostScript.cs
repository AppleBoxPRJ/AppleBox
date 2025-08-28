using UnityEngine;
using UnityEngine.SceneManagement;

public class totallyLostScript : MonoBehaviour
{
    public Animator lost;

    [SerializeField] private Animator finalCanva;
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

    public void stopAnimation()
    {
        lost.SetBool("lost", false);
    }

    public void StartFinalCanva()
    {
        finalCanva.SetBool("anim", true);
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
