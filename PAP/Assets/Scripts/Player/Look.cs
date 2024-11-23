using UnityEngine;

public class Look : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 300f;
    float xRotation = 0f;
    
    void Start()
    {
        //Lock cursos to center of the screen and hide it
        Cursor.lockState =CursorLockMode.Locked;
    }

    void Update()
    {
        //Reads the mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //Keeping track of rotation
        xRotation -= mouseY;
        //Not letting X rotation go below -90 or above 90, so that player doesn't look backwards by looking up or down too much
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //Aplying rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
