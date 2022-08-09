using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Stats
{
    [SerializeField] GameObject canvas;

    [SerializeField] Rigidbody rb;

    void Update()
    {
        if (!isAlive)
            return;
        CheckDeath();
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
        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }

    void JumpLogic()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    void CheckDeath()
    {
        if (hp <= 0)
            Death();
    }

    void Death()
    {
        hp = 0;
        isAlive = false;
        print("death");
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
            isGrounded = value;
        }
    }
}
