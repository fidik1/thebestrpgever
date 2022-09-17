using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float maxHp { get; protected set; } 
    public float hp { get; protected set; } 
    public float maxMana { get; protected set; }
    public float mana { get; protected set; }
    public float lvl { get; protected set; } 
    public float targetXp { get; protected set; } 
    public float xp { get; protected set; } 
    public float dmg { get; protected set; } 
    public float attackSpeed { get; protected set; } 
    public float speed { get; protected set; } 
    public float jumpForce { get; protected set; }
    public bool isAlive = true;
    public bool isGrounded;
    public float regenHp { get; protected set; }
    public float regenMana { get; protected set; }

    public delegate void PlayerEvent();
    public static event PlayerEvent ChangedHP;
    public static event PlayerEvent ChangedMana;
    public static event PlayerEvent ChangedXP;

    void Awake()
    {   
        InitStats();
        StartCoroutine(RegenStats());
        ChangedHP += CheckDeath;
        ChangedXP += CheckLvlUp;
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

    IEnumerator RegenStats()
    {
        while (isAlive)
        {
            hp += regenHp / 2;
            hp = Mathf.Min(maxHp, hp);

            mana += regenMana / 2;
            mana = Mathf.Min(maxMana, mana);

            ChangedHP?.Invoke();
            ChangedMana?.Invoke();
            yield return new WaitForSeconds(.5f);
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
            Death();
    }

    void Death()
    {
        hp = 0;
        isAlive = false;
        print("death");
    }

    public void SpendHP(float HP)
    {
        this.hp -= HP;
        ChangedHP?.Invoke();
    }

    public void SpendMana(float mana)
    {
        this.mana -= mana;
        ChangedMana?.Invoke();
    }

    public void ChangeSpeed(float movementSpeed)
    {
        this.speed = movementSpeed;
    }

    public void ChangeXP(float xp)
    {
        this.xp += xp;
        ChangedXP?.Invoke();
    }

    void OnDestroy()
    {
        ChangedHP -= CheckDeath;
        ChangedXP -= CheckLvlUp;
    }
}
