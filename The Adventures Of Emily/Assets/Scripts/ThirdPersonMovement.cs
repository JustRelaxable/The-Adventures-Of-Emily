using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    public event Action OnCharacterLandedAfterDoubleJump;
    private CharacterController characterController;
    [SerializeField]
    private float speed = 6f;

    [SerializeField]
    bool lockCursor = true;
    [SerializeField]
    private float turnSmoothTime = 0.1f;
    [SerializeField]
    private float jumpForce = 10f;
    float turnSmoothVelocity;
    float vSpeed = 0;
    private bool secondJump = false;
    private bool firstJump = false;
    private bool previousGroundedStatus = true;
    [SerializeField]
    private float gravityMultiplier = 0.5f;
    private float gravity = 9.81f;
    public bool landing = false;

    [SerializeField]
    private float soarSpeed = 1f;

    public Transform cam;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        OnCharacterLandedAfterDoubleJump += () =>
        {
            Debug.Log("Landed after double jump!");
            secondJump = false;
        };
    }

    private void Start()
    {
        HandleCursorMode();
    }

    private void HandleCursorMode()
    {
        if (lockCursor)
            Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction;
        if (!landing)
            direction = new Vector3(horizontal, 0f, vertical);
        else
            direction = Vector3.zero;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        animator.SetFloat("TurnSmoothVelocity", turnSmoothVelocity);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        if (direction.magnitude <= 0.1f)
        {
            moveDir = Vector3.zero;
            animator.SetBool("Running", false);
        }
        else
        {
            animator.SetBool("Running", true);
        }

        if (characterController.isGrounded)
        {
            vSpeed = -0f;
            //print("character grounderd");
            firstJump = false;
            animator.SetBool("IsGrounded", true);
        }
        else
        {
            animator.SetBool("IsGrounded", false);
            if(Input.GetKey(KeyCode.Space) && vSpeed <= 0)
            {
                vSpeed = -soarSpeed * Time.deltaTime;
                animator.SetBool("SpaceDown", true);
            }
            else
            {
                animator.SetBool("SpaceDown", false);
                vSpeed -= gravity * gravityMultiplier * Time.deltaTime;
                //print("character not grounded");
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!firstJump && !secondJump)
            {
                animator.SetTrigger("Jump");
                //print("fisrt jump");
                vSpeed = jumpForce;
                firstJump = true;
            }
            else if (firstJump && !secondJump)
            {
                //print("second jump");
                animator.SetTrigger("Jump");
                vSpeed = jumpForce;
                secondJump = true;
            }
        }

        moveDir.y = vSpeed;
        characterController.Move(moveDir * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("AttackTest");
        }


        if (!previousGroundedStatus && secondJump && characterController.isGrounded)
        {
            OnCharacterLandedAfterDoubleJump?.Invoke();
        }
        previousGroundedStatus = characterController.isGrounded;
        animator.SetFloat("vSpeed", vSpeed);
    }


}
