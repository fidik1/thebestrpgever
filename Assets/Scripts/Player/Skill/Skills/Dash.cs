using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Skill
{
    [SerializeField] AttributeSkill attributeSkill;
    public override AttributeSkill attribute { get { return attributeSkill; } set { attributeSkill = value;} }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !attribute.onCooldown)
        {
            ActivateSkill();
            StartCoroutine(DoDash());
        }
    }

    public override void ActivateSkill()
    {
        StartCoroutine(Cooldown());
    }
    
    IEnumerator DoDash()
    {
        player.ChangeSpeed(player.speed * 2);
        yield return new WaitForSeconds(0.5f);
        player.ChangeSpeed(player.speed / 2);
    }
}
