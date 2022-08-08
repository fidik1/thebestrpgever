using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    // --- stats begin ---
    public float maxHp { get; set; } 
    public float hp { get; set; } 
    public float maxMana { get; set; }
    public float mana { get; set; }
    public float lvl { get; set; } 
    public float dmg { get; set; } 
    public float attackSpeed { get; set; } 
    public float speed { get; set; } 
    public bool isAlive = true;
    public float regenHp { get; set; }
    public float regenMana { get; set; }
    // --- stats end ---

    void Start()
    {
        InitStats();
    }

    void InitStats()
    {
        maxHp = 100;
        hp = maxHp;
        maxMana = 100;
        mana = maxMana;
        lvl = 1;
        dmg = 10;
        attackSpeed = 1;
        speed = 5;
        isAlive = true;
        regenHp = 1;
        regenMana = 1;
    }
    
    void Update()
    {
        MovementLogic();
        CheckDeath();
    }

    void MovementLogic() // Movement
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
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

    void GetDamage()
    {

    }
}
