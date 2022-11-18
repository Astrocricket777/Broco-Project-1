using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [Header("References")]
    public CharacterController Controller;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    public GameObject Cam;
    public CameraScript Camm;

    [Header("Settings")]
    public float Speed = 6f;
    public float SprintSpeed = 12f;
    public float Gravity = -9.81f;
    public float JumpHeight = 3f;

    Vector3 Velocity;
    bool IsGrounded;

    void Start()
    {
        
        
        Cam.gameObject.SetActive(true);
        

        
    }

    void Update()
    {
        
        
        return;
        

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        

        Camm.CameraLook();
        PlayerMove();
        Jump();
        Sprint();
    }

    private void PlayerMove()
    {
        // Setting The "IsGrounded" Bool To Be True If The Sphere Raycast Detects Something.
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (IsGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        // Getting Input From "WASD" And Assigning that To The "x" and "y" Variables
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Defining A Move Variable In Order To Orientate Ourselves
        Vector3 Move = transform.right * x + transform.forward * z;

        // Actually Moving The Player With the "Move" Function On The Character Controller.
        Controller.Move(Move * Speed * Time.deltaTime);

        // Assigning The Velocity On The y Axis
        Velocity.y += Gravity * Time.deltaTime;

        Controller.Move(Velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = SprintSpeed;
        }
        else
        {
            Speed = 6f;
        }
    }
}
