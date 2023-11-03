using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float speed = 1;
    public float mouseSensative = 1;
    public float jumpStrength = 5;

    private Vector3 playerVelocity;
    private float gravityValue = -9.8f;

    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {

        bool grounded = characterController.isGrounded;

        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }


        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 moveVector = Camera.main.transform.forward * moveY + Camera.main.transform.right * moveX;
        characterController.Move(moveVector * speed * Time.deltaTime);
        

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * mouseSensative, 0);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpStrength * -3 * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

    }


}
