using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float hassasiyet = 100f; // Sensitivity for mouse movement 
    public Transform karakter; // Reference to the character transform

    public float xRotation = 0f; // Rotation around the X-axis
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * hassasiyet * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * hassasiyet * Time.deltaTime;
        xRotation -= mouseY; // Invert the Y-axis rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the rotation to prevent flipping

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        karakter.Rotate(Vector3.up * mouseX);
    }
}
