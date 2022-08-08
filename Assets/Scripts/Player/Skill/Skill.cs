using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public virtual AttributeSkill attribute { get; set; }
    public PlayerController player;
    public Vector3 rayStartPos = new Vector3(Screen.width/2, Screen.height/2, 0);

    void Start()
    {
        attribute.onCooldown = false;
    }

    public void Activate()
    {
        ActivateSkill();
        StartCoroutine(Cooldown());
        PlayerStatsUpdate();
        attribute.timePassed = 0;

    }

    public virtual void ActivateSkill()
    {
        Debug.Log("Activate");
    }

    public IEnumerator Cooldown()
    {
        attribute.onCooldown = true;
        yield return new WaitForSeconds(attribute.cooldown);
        attribute.onCooldown = false;
    }

    void PlayerStatsUpdate()
    {
        player.mana -= attribute.manaCost;
    }

}
