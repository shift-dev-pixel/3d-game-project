using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private CharacterController characterController;
    public Transform Orientation;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    void Start()
    { 
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y  < 0 ) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Orientation.transform.right * x + Orientation.transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        //jumping
        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // fall
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
        lastPosition = gameObject.transform.position;
    }
}
