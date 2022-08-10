using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    [SerializeField] Rigidbody rb;
    [SerializeField] Stats stats;

    void Update()
    {
        if (!stats.isAlive)
            return;
        JumpLogic();
    }

    void FixedUpdate()
    {
        MovementLogic();
    }    
    
    void MovementLogic()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        transform.Translate(movement * stats.speed * Time.fixedDeltaTime);
    }

    void JumpLogic()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (stats.isGrounded)
            {
                rb.AddForce(Vector3.up * stats.jumpForce, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            stats.isGrounded = value;
        }
    }
}
