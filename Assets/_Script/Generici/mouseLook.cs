using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSens;
    [SerializeField] private Transform _cameratransform;
    [SerializeField] private SettingsScript _settings;

    private float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        _mouseSens = _settings.sens;
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
