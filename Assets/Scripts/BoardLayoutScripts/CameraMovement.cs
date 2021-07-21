using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraTransform;

    public float scrollSpeed = 200f;
    //public float minY = 20f;
    //public float maxY = 120f;
    public float normalSpeed;
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;

    void Start()
    {
        newRotation = transform.rotation;
        newPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {

        HandleMovementInput();

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        newPosition.y -= scroll * scrollSpeed * 5000f * Time.deltaTime;


        //pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        //pos.y = Mathf.Clamp(pos.y, minY, maxY);
        //pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);


    }

    void HandleMovementInput()
    {
        if (Input.GetKey("w"))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey("s"))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey("d"))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey("a"))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        if (Input.GetKey("q"))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey("e"))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
    }



}
