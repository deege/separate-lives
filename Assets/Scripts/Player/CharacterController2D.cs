using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 2.0f;
    private bool isJumping = false;
    private Rigidbody rb;

    void Start()
    {
        // get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // restrict movement along the Z axis
        rb.position = new Vector3(rb.position.x, rb.position.y, 0);

        float moveHorizontal = Input.GetAxis("Horizontal");

        // create a new vector for the new position
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        // set the velocity, which will cause the character to move
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, 0.0f);

        if (!isJumping && Input.GetButtonDown("Jump")) // assuming you're using Unity's default "Jump" button mapping
        {
            isJumping = true;
            rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // if the character is touching the ground, they are able to jump
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}

