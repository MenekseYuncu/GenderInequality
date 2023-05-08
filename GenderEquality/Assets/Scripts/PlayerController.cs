using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    CharacterController character;
    [SerializeField] Transform mainCamera;
    [SerializeField] float trueSpeed = 20f;
    [SerializeField] float jumpforce = 25f;
    //Rigidbody rigidbody;
    private Vector3 oldPosition;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        character = gameObject.GetComponent<CharacterController>();
        //rigidbody = GetComponent<Rigidbody>();
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * trueSpeed, 0, Input.GetAxis("Vertical") * trueSpeed);

        character.Move(move * Time.deltaTime);

        animator.SetBool("isRun", Input.GetKey(KeyCode.W));
        animator.SetBool("isDance", Input.GetKey(KeyCode.X));
        animator.SetBool("isJump", Input.GetKey(KeyCode.Space));

        if (transform.position.z < oldPosition.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, oldPosition.z);
        }

        oldPosition = transform.position;

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
        }
    }

}
