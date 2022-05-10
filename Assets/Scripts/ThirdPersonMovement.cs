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
    [SerializeField] private LayerMask groundLayer;

    private CharacterController characterController;
    private ThirdPersonInput thirdPersonInput;

    private float turnSmoothVelocity, vSpeed,timePassedSinceLastJump;
    private bool firstJump, secondJump = false;
    private bool isGrounded;
    private const float GRAVITY = 9.81f;
    private Vector3 characterDirection;
    private Vector3 lastMoveDirection;
    private Vector3 moveDir;

    public float TurnSmoothVelocity { get => turnSmoothVelocity; }
    public Vector3 CharacterDirection { get => characterDirection; }
    public bool IsGrounded { get => characterController.isGrounded; }
    public float VerticalSpeed { get => vSpeed; }
    public bool FirstJump { get => firstJump; }
    public bool SecondJump { get => secondJump; }
    public float JumpForce { get => jumpForce; set=> jumpForce = value; }

    public event Action OnJump;

    public bool onIce = false;
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
        moveDir = characterDirection != Vector3.zero ? Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward : Vector3.zero;
        timePassedSinceLastJump += Time.deltaTime;

        CalculateIsGrounded();

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
        else if(IsGrounded && !firstJump && !secondJump)
        {
            vSpeed = 0;
        }

        if(IsGrounded && timePassedSinceLastJump >= jumpRate)
        {
            firstJump = false;
            secondJump = false;
        }

        if (onIce)
        {
            lastMoveDirection -= lastMoveDirection * Time.deltaTime;
            lastMoveDirection += moveDir * Time.deltaTime;
            characterController.Move(lastMoveDirection * speed * Time.deltaTime);
            return;
        }

        moveDir.y = vSpeed;
        characterController.Move(moveDir * speed * Time.deltaTime);
    }

    private void CalculateIsGrounded()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        Debug.DrawRay(transform.position, -transform.up*0.5f, Color.red);
        isGrounded = Physics.Raycast(ray,0.5f,groundLayer);
    }

    private void ThirdPersonInput_JumpPressed()
    {
        if (!firstJump && !secondJump && timePassedSinceLastJump >= jumpRate)
        {
            vSpeed = jumpForce;
            firstJump = true;
            timePassedSinceLastJump = 0f;
            OnJump?.Invoke();
        }
        else if (firstJump && !secondJump)
        {
            vSpeed = jumpForce;
            secondJump = true;
            OnJump?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    }

    public void OnEnterIce()
    {
        lastMoveDirection = moveDir;
    }

    public void Hit()
    {
        StartCoroutine(HitCo());
    }

    private IEnumerator HitCo()
    {
        float duration = 1;
        float time = 0;
        while (time<=duration)
        {
            characterController.Move(transform.up * Time.deltaTime * 10);
            characterController.Move(-transform.forward * speed*Time.deltaTime);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
