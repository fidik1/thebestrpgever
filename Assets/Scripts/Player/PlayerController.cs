using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    public Rigidbody rb;

    // --- stats begin ---
    public float maxHp { get; set; } 
    public float hp { get; set; } 
    public float maxMana { get; set; }
    public float mana { get; set; }
    public float lvl { get; set; } 
    public float targetXp { get; set; } 
    public float xp { get; set; } 
    public float dmg { get; set; } 
    public float attackSpeed { get; set; } 
    public float speed { get; set; } 
    public float jumpForce { get; set; }
    public bool isAlive = true;
    public bool isGrounded;
    public float regenHp { get; set; }
    public float regenMana { get; set; }
    // --- stats end ---

    void Start()
    {   
        InitStats();
        StartCoroutine(RegenStats());
    }

    void Update()
    {
        if (!isAlive)
            return;
        CheckLvlUp();
        CheckDeath();
        JumpLogic();
    }

    void FixedUpdate()
    {
        MovementLogic();
    }

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
        jumpForce = 1;
        isAlive = true;
        regenHp = 1;
        regenMana = 1;
    }
    
    void MovementLogic() // Movement
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

    public void CheckLvlUp()
    {
        if (xp >= targetXp)
        {
            StatsUp();
            
            hp = maxHp;
        }
    }

    void StatsUp()
    {
        xp -= targetXp;
        lvl += 1;
        maxHp = Mathf.Round(maxHp * 1.1f);
        targetXp *= 2f;
        attackSpeed += 1;
    }
    
    void CheckDeath()
    {
        if (hp <= 0)
        {
            hp = 0;
            Death();
        }
        if (hp >= maxHp)
            hp = maxHp;
        if (mana >= maxMana)
            mana = maxMana;
    }

    IEnumerator RegenStats()
    {
        while (isAlive)
        {
            if (hp < maxHp)
                hp += regenHp/2;
            if (mana < maxMana)
                mana += regenMana/2;
            yield return new WaitForSeconds(.5f);
        }
    }

    void Death()
    {
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

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = value;
        }
    }
}
