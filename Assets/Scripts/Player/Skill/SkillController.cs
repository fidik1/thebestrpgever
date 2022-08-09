using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public Player player;
    public List<Skill> skills;
    [SerializeField] int skillID = 0;

    SkillHud skillHud;

    void Start()
    {
        skillHud = GetComponent<SkillHud>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            skillID = 0;
            Activate();
        }
        if (Input.GetKey(KeyCode.E))
        {
            skillID = 1;
            Activate();
        }
        if (Input.GetKey(KeyCode.R))
        {
            skillID = 2;
            Activate();
        }
        if (Input.GetKey(KeyCode.F))
        {
            skillID = 3;
            Activate();
        }
        if (Input.GetKey(KeyCode.C))
        {
            skillID = 4;
            Activate();
        }
    }

    void Activate()
    {
        if (!skills[skillID].attribute.onCooldown && player.mana >= skills[skillID].attribute.manaCost)
        {
            skills[skillID].Activate();
            skillHud.SetSliderValue(skillID);
        }
    }
}
