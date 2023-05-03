using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public static Transform instance;

    [Header("Movement Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;

    private Vector3 moveDirection = Vector3.zero;

    private CharacterController cc;

    [SerializeField] AudioSource runningSound;
   

    [Header("Gravity")]
    [SerializeField] private float gravity;
    [SerializeField] private float groudDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isCCGrounded = false;
    private Vector3 velocity = Vector3.zero;

    [Header("Animations")]
    private Animator anim;

    public void Awake()
    {
        instance = this.transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        GetRefrences();
        InitialVariables();

    

    }

    private void Update()
    {
        HandleIsGrounded();
        HandleJump();
        HandleGravity();


        HandleRunning();
        HandleMovement();
        HandleAnimation();
    }



    private void GetRefrences()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void InitialVariables()
    {
        moveSpeed = walkSpeed;
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = moveDirection.normalized;
        moveDirection = transform.TransformDirection(moveDirection);


        cc.Move(moveDirection * moveSpeed * Time.deltaTime);
       
    }

    private void HandleRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
            runningSound.Play();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed;
            runningSound.Stop();
        }
    }

    private void HandleIsGrounded()
    {
        isCCGrounded = Physics.CheckSphere(transform.position, groudDistance, groundMask);
    }

    private void HandleGravity()
    {

        if (isCCGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isCCGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
        }

    }


    private void HandleAnimation()
    {
        if (moveDirection == Vector3.zero)
        {
            anim.SetFloat("Speed", 0f, 0.2f, Time.deltaTime);
        }
        else if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 0.25f, 0.2f, Time.deltaTime);
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 0.5f, 0.2f, Time.deltaTime);
        }
    }
}
