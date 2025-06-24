using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 400f;
    public Transform PlayerBody;

    public float xRotation = 0f;
    
    void Update()
    {
        //get axis to watch
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        
        //setup Y field of view
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        //actual view movement
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
