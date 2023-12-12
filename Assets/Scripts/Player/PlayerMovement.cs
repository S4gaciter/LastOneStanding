using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Reference Setup")]
    public PlayerStats stats;
    public float playerHeight;
    public KeyCode jumpKey;
    public LayerMask ground;
    public Transform orientation;

    // Private Variables
    private Vector3 moveVector;

    private float horizontal;
    private float vertical;
    private float baseSpeed;

    private Rigidbody rb;

    bool grounded;
    bool readyToJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if player is on ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);

        GetInputs();
        SpeedControl();

        if (grounded)
        {
            rb.drag = stats.groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), stats.jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveVector = orientation.forward * vertical + orientation.right * horizontal;

        // On ground
        if (grounded)
        {
            rb.AddForce(moveVector.normalized * stats.moveSpeed * 10f, ForceMode.Force);
        }

        // In air
        else if (!grounded)
        {
            rb.AddForce(moveVector.normalized * stats.moveSpeed * 10f * stats.airMultiplier, ForceMode.Force);
        }
    }
    private void Jump()
    {
        // Reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        rb.AddForce(transform.up * stats.jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > stats.moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * stats.moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
