using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame
    void Update()
    {
        GroundMovement();
    }

    void GroundMovement()
    {
        //get input from player
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //translate input to ground movement
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);

    }
}
