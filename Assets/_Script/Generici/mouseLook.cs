using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSens = 1f;
    [SerializeField] private Transform _cameratransform;

    private float pitch;
    
    void Update()
    {
        ProcessLook();
    }

    private void ProcessLook() {
        var lookInput = InputBindings.Instance.LookAction.ReadValue<Vector2>();

        pitch += lookInput.y * _mouseSens * -1f;
        pitch = Mathf.Clamp(pitch, -89, 89);

        _cameratransform.localRotation = Quaternion.Euler(pitch, 0, 0);
        transform.Rotate(Vector3.up * (lookInput.x * _mouseSens));
    }
}
