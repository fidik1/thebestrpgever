using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Enemy
{
    [SerializeField] GameObject player;

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

    void FixedUpdate()
    {
        MovementLogic();
    }

    void MovementLogic() // Movement
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
}
