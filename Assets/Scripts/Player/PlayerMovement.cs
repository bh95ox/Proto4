using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public Transform cameraContainer;
    [SerializeField] private Transform Spawnpoint;
    [SerializeField] private float threshold;
    

    [SerializeField] private Camera _camera;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float RunSpeed;
    public float mouseSensitivity = 3f;
    public float gravity = 20.0f;
    [SerializeField] private float lookUpClamp;
    [SerializeField] private float lookDownClamp;

    private Vector3 moveDirection = Vector3.zero;
    float rotateX, rotateY;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        gameObject.transform.position= Spawnpoint.position;
    
    }
    private void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            gameObject.transform.position = Spawnpoint.position;

        }
    }

    void Update()
    {
        Locomotion();
        RotateAndLook();
    }

    private void Locomotion()
    {
        if (characterController.isGrounded) // When grounded, set y-axis to zero (to ignore it)
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                moveDirection = transform.TransformDirection(moveDirection * RunSpeed); //Run 
                //Audio 
            }
            else
            {
                moveDirection = transform.TransformDirection(moveDirection);
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))// Zoom POV
            {
                _camera.fieldOfView = 25;
            }
            else
            {
                _camera.fieldOfView = 60;
            }
            moveDirection *= moveSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }

        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

    }

    private void RotateAndLook()
    {
        rotateX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotateY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotateY = Mathf.Clamp(rotateY, lookUpClamp, lookDownClamp);
        transform.Rotate(0f, rotateX, 0f);
        cameraContainer.transform.localRotation = Quaternion.Euler(rotateY, 0f, 0f);
    }

}
