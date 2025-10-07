using UnityEngine;

public class headBobbingScript : MonoBehaviour
{
    private Animator _animator;
    //private AudioManager _audioManager;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        SetBobbing(PlayerMovement.move.magnitude >= 0.1f);
    }

    private void SetBobbing(bool bobbing)
    {
        _animator.SetBool("bobbing", bobbing);
    }

    public void StepsSound()
    {
        var randomSound = Random.Range(0, 2);
        Debug.Log(randomSound);
        if (randomSound == 0)
        {
           AudioManager.Instance.PlaySFX("step"); 
        }
        else
        {
            AudioManager.Instance.PlaySFX("step1"); 
        }
    }
}
