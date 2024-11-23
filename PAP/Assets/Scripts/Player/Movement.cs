using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    void Update()
    {
        //Get input for walking
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Create Movement Vector
        Vector3 move = transform.right * x + transform.forward * z;
        //Apply Movement
        controller.Move(move * speed * Time.deltaTime);
    }
}
