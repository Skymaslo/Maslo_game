using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float speed = 1;
    public float mouseSensative = 1;
    public float jumpStrength = 5;
    public GameObject GroundCheaker;
    public float GroundCheckRadius;
    public LayerMask ignoreLayer;

    private Vector3 playerVelocity;
    private float gravityValue = -9.8f;
    private Animator animator;

    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //bool grounded = characterController.isGrounded;
        bool grounded = IsGrounded();

        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }


        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 moveVector = Camera.main.transform.forward * moveY + Camera.main.transform.right * moveX;
        moveVector.y = 0;

        float moveSpeed = moveVector.sqrMagnitude;
        animator.SetFloat("Speed", moveSpeed);

        characterController.Move(moveVector * speed * Time.deltaTime);
        

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * mouseSensative, 0);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpStrength * -3 * gravityValue);
            animator.SetTrigger("jump");
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

    }

    private void OnDrawGizmos()
    {
        Color32 color = Color.green;
        color.a = 128;
        Gizmos.color = color;

        Gizmos.DrawSphere(GroundCheaker.transform.position, GroundCheckRadius);
    }
    public bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(GroundCheaker.transform.position, GroundCheckRadius, ignoreLayer);
        if(colliders.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
