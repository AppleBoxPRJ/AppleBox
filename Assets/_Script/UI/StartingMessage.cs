using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class StartingMessage : MonoBehaviour
{
    void OnEnable()
    {
        InputBindings.Instance.InteractAction.performed += Destroy;
    }

    void OnDisable()
    {
        InputBindings.Instance.InteractAction.performed  -= Destroy;
    }

    private void Destroy(InputAction.CallbackContext ctx)
    {
        Destroy(gameObject);
    }
}
