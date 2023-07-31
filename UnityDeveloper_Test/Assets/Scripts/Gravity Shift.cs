using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShift : MonoBehaviour
{
    private Rigidbody rb;

    //Set initial gravity direction is downwards
    private Vector3 currentGravityDirection = Vector3.down;
    public float gravityForce;

    //Setup direction reference hologram
    public GameObject hologramPrefab;
    private GameObject hologramInstance;
    public bool isGravityShifted = false;
    public float hologramPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Instantiate the hologram prefab but hidden
        hologramInstance = Instantiate(hologramPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
        hologramInstance.SetActive(false);
    }

    void Update()
    {
        SetGravityDir();

        if (isGravityShifted)
        {
            //Apply gravity in the current gravity direction
            Vector3 gravity = currentGravityDirection * gravityForce;
            rb.AddForce(gravity, ForceMode.Acceleration);

            //Rotate character to new gravity direction
        }
    }

    void SetGravityDir()
    {
        //Change gravity direction according to arrow key pressed
        if(Input.GetKey(KeyCode.I))
        {
            currentGravityDirection = Vector3.up;
            ShowHologram();
        }
        else if(Input.GetKey(KeyCode.K))
        {
            currentGravityDirection = Vector3.down;
            ShowHologram();
        }
        else if(Input.GetKey(KeyCode.J))
        {
            currentGravityDirection = Vector3.left;
            ShowHologram();
        }
        else if(Input.GetKey(KeyCode.L))
        {
            currentGravityDirection = Vector3.right;
            ShowHologram();
        }

        //Toggle gravity
        if (Input.GetKeyDown(KeyCode.O))
        {
            isGravityShifted = !isGravityShifted;
            hologramInstance.SetActive(isGravityShifted);
            
            //Disable hologram
            hologramInstance.SetActive(false);
        }
    }

    private void ShowHologram()
    {
        //Make hologram visible
        hologramInstance.SetActive(true);

        //Switch hologram indicating current gravity direction
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, currentGravityDirection);
        hologramInstance.transform.position = transform.position + Vector3.up * hologramPos;
        hologramInstance.transform.rotation = targetRotation;
    }
}
