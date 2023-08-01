using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    public float moveSpeed;
    private float horizontalInput;
    private float forwardInput;

    public float jumpForce;
    public bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GroundMovement();

        Jump();
    }
    
    //Allow jump only after touching ground again
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isFalling", false);
        }
    }

    void GroundMovement()
    {
        //Get input from player
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Translate input to ground movement
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);

        //Animations
        if(horizontalInput == 0 && forwardInput == 0)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false) ;
        }
        else
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", true);
        }

    }

    void Jump()
    {
        //Check if jump button pressed before jumping
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetBool("isFalling", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
