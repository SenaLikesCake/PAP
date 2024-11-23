using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.1f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        //Check if player is grounded (Necessary for gravity calculations)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //If player is grounded and moving downward, reset velocity (-2 in order to snap player to the ground)
        if (isGrounded && velocity.y < 0){
            velocity.y = -2;
        }

        //Get input for walking
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Create Movement Vector
        Vector3 move = transform.right * x + transform.forward * z;
        //Apply Movement
        controller.Move(move * speed * Time.deltaTime);

        //Get input for jumping
        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }


        //Calculating Gravity
        velocity.y  += gravity * Time.deltaTime;
        //Applying Gravity (Δy=gt² )
        controller.Move(velocity * Time.deltaTime);
    }
}
