using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    CharacterController character;
    [SerializeField] Transform mainCamera;
    [SerializeField] float trueSpeed = 15f;
    [SerializeField] float jumpforce = 10f;
    Rigidbody rb;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        character = gameObject.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * trueSpeed, 0, Input.GetAxis("Vertical") * trueSpeed);

        character.Move(move * Time.deltaTime);

        animator.SetBool("isRun", Input.GetKey(KeyCode.W));
        animator.SetBool("isDance", Input.GetKey(KeyCode.X));
        animator.SetBool("isJump", Input.GetKey(KeyCode.Space));
    }
    


}
