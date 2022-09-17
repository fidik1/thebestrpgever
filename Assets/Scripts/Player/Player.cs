using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Enemy
{
    [SerializeField] Animations anim;

    [SerializeField] GameObject canvas;

    [SerializeField] Rigidbody rb;

    public float horizontal { get; private set; }
    public float vertical { get; private set; }

    void InitStats()
    {
        maxHp = 100;
        hp = maxHp;
        maxMana = 100;
        mana = maxMana;
        lvl = 1;
        targetXp = 10;
        xp = 0;
        dmg = 10;
        attackSpeed = 1;
        speed = 10;
        jumpForce = .5f;
        isAlive = true;
        regenHp = 1;
        regenMana = 1;
    }

    void Update()
    {
        if (!isAlive)
            return;
        JumpLogic();
    }

    void FixedUpdate()
    {
        if (!isAlive)
            return;
        MovementLogic();
    }    
    
    void MovementLogic()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
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
                anim.Jump();
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
            isGrounded = value;
        }
    }
}
