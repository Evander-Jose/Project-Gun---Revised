using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController charController;
    [Space]
    public Transform groundCheckLocation;
    public float groundCheckRadius;
    public LayerMask groundMask;
    [Space]
    public float speed;
    public float gravity;
    [Space]
    public float jumpHeight;
    [Range(0f, 1f)] public float jumpMultiplier; //When jumping, gravity is multiplied by this
    [Range(1f, 2f)] public float jumpFallMultiplier; //Falling from jump, gravity is multiplied by this
    private Vector3 velocity;

    private float defaultGravity = 0f;

    private bool isGrounded = true;

    private void Start()
    {
        defaultGravity = gravity;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDir = horizontalInput * transform.right + verticalInput * transform.forward;
        moveDir.Normalize();
        charController.Move(moveDir * Time.deltaTime * speed);

        //Velocity reset:
        if (velocity.y < 0f && isGrounded)
        {
            velocity.y = -2f;
        }


        //Applying jump force:
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);            
        }

        //If the player is shot up (hopefully by jumping), then reduce gravity:
        if(velocity.y < 0f)
        {
            gravity = defaultGravity;
        }
        else if (velocity.y > 0f)
        {
            if (Input.GetButton("Jump"))
                gravity = defaultGravity * jumpMultiplier;
            else
                gravity = defaultGravity * jumpFallMultiplier;
        }

        velocity.y += 0.5f * gravity * Time.deltaTime;

        //Applying gravity, with the equation: y = 1/2gt^2
        charController.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheckLocation.transform.position, groundCheckRadius, groundMask);
    }
}
