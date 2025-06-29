using UnityEngine;

public class headBobbingScript : MonoBehaviour
{
    private Animator _animator;

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
}
