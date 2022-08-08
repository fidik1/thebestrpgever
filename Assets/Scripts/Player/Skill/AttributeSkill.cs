using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Attribute", menuName = "Spell/Attribute")]
public class AttributeSkill : ScriptableObject
{
    [Header("Description")]
    public string skillName;
    public int skillID;
    public Sprite icone;

    [Header("Attribute")]
    public float cooldown;
    public float timePassed;
    public bool onCooldown = false;
    public int manaCost;
    public float damage;
    public float heal;
}
