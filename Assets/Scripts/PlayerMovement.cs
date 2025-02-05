using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private Vector2 moveInput;
    private bool canJump = false;
    private float jumpInput;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 newVelocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
        if (canJump)
        {
            rb.AddForce(0, jumpInput * jumpForce, 0);
            canJump = false;
        }

        rb.velocity = transform.rotation * newVelocity;
    }


    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        jumpInput = value.Get<float>();
        canJump = true;
    }
}
