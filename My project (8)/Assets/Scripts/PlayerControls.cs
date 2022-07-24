using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public CharacterController controller;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed;
    public float gravityValue;
    public GameObject activeChar;
    public float moveHorizontal;
    public float moveVertical;
    public float speed = 4;
    public float rotateSpeed = 4;
    public float jumpHeight = 1.0f;
    public bool isJumping;

    void Start()
    {
        playerSpeed = 4;
        gravityValue = -19.8f;
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            isJumping = true;
            activeChar.GetComponent<Animator>().Play("Jump");
            playerVelocity.y += 10;
            StartCoroutine(ResetJump());
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            this.gameObject.GetComponent<CharacterController>().minMoveDistance = 0.001f;
            if (isJumping == false)
            {
                activeChar.GetComponent<Animator>().Play("Standard Run");
            }
        }
        else
        {
            this.gameObject.GetComponent<CharacterController>().minMoveDistance = 0.901f;
            if (isJumping == false)
            {
                activeChar.GetComponent<Animator>().Play("Idle");
            }
        }
    }
    
    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.9f);
        isJumping = false;
    }
}
