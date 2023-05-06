using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    CharacterController character;
    [SerializeField] Transform mainCamera;
    [SerializeField] float trueSpeed = 15f;
    [SerializeField] float jumpSpeed = 3.6f;
    [SerializeField] Vector3 move = Vector3.zero;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float horizontalInput;
    [SerializeField] float forwardInput;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        character = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * trueSpeed, 0, Input.GetAxis("Vertical") * trueSpeed);

        character.Move(move * Time.deltaTime);

        animator.SetBool("isRun", Input.GetKey(KeyCode.W));
        animator.SetBool("isDance", Input.GetKey(KeyCode.X));

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        hareket();
    }

    void hareket()
    {
        // zýplama kodu
        if (character.isGrounded)
        {

            move = transform.right * horizontalInput + transform.forward * forwardInput;

            if (Input.GetButton("Jump"))
            {
                move.y = jumpSpeed;
            }
        }
        move.y -= gravity * Time.deltaTime;
        character.Move(move * trueSpeed * Time.deltaTime);
    }
}
