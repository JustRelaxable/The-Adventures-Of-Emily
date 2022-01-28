using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private float soarSpeed = 1f;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravityMultiplier = 0.5f;
    [SerializeField] private Transform thirdPersonCamera;
    [SerializeField] private float jumpRate = 0.5f;

    private CharacterController characterController;
    private ThirdPersonInput thirdPersonInput;

    private float turnSmoothVelocity, vSpeed,timePassedSinceLastJump;
    private bool firstJump, secondJump = false;
    private const float GRAVITY = 9.81f;
    private Vector3 characterDirection;

    public float TurnSmoothVelocity { get => turnSmoothVelocity; }
    public Vector3 CharacterDirection { get => characterDirection; }
    public bool IsGrounded { get => characterController.isGrounded; }
    public float VerticalSpeed { get => vSpeed; }
    public bool FirstJump { get => firstJump; }
    public bool SecondJump { get => secondJump; }



    private void Awake()
    {
        thirdPersonInput = GetComponent<ThirdPersonInput>();
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        thirdPersonInput.JumpPressed += ThirdPersonInput_JumpPressed;
        timePassedSinceLastJump = jumpRate;
    }

    private void Update()
    {
        characterDirection = new Vector3(thirdPersonInput.HorizontalInput, 0f, thirdPersonInput.VerticalInput);
        float targetAngle = Mathf.Atan2(characterDirection.x, characterDirection.z) * Mathf.Rad2Deg + thirdPersonCamera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = characterDirection != Vector3.zero ? Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward : Vector3.zero;
        timePassedSinceLastJump += Time.deltaTime;

        if (!IsGrounded)
        {
            if (thirdPersonInput.JumpHold && VerticalSpeed <= 0)
            {
                vSpeed = -soarSpeed;
            }
            else
            {
                vSpeed -= GRAVITY * gravityMultiplier * Time.deltaTime;
            }
        }

        if(IsGrounded && timePassedSinceLastJump >= jumpRate)
        {
            firstJump = false;
            secondJump = false;
        }

        moveDir.y = vSpeed;
        characterController.Move(moveDir * speed * Time.deltaTime);
    }


    private void ThirdPersonInput_JumpPressed()
    {
        if (!firstJump && !secondJump && timePassedSinceLastJump >= jumpRate)
        {
            vSpeed = jumpForce;
            firstJump = true;
            timePassedSinceLastJump = 0f;
        }
        else if (firstJump && !secondJump)
        {
            vSpeed = jumpForce;
            secondJump = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("X");
    }

}
