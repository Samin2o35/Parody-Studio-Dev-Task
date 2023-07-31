using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShift : MonoBehaviour
{
    //Set initial gravity direction is downwards
    private Vector3 currentGravityDirection = Vector3.down;
    public float gravityForce;

    void Update()
    {
        SetGravityDir();
        
        // Apply gravity in the current gravity direction
        Vector3 gravity = currentGravityDirection * gravityForce;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    void SetGravityDir()
    {
        //Set gravity direction according to arrow key pressed
        if(Input.GetKeyDown(KeyCode.I))
        {
            currentGravityDirection = Vector3.up;
        }
        else if(Input.GetKeyDown(KeyCode.K))
        {
            currentGravityDirection = Vector3.down;
        }
        else if(Input.GetKeyDown(KeyCode.J))
        {
            currentGravityDirection = Vector3.left;
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            currentGravityDirection = Vector3.right;
        }
    }
}
