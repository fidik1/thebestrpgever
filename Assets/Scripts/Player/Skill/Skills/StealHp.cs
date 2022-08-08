using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealHp : Skill
{
    [SerializeField] GameObject skillPrefab;
    bool cast;

    [SerializeField] AttributeSkill attributeSkill;
    public override AttributeSkill attribute { get { return attributeSkill; } set { attributeSkill = value;} }

    public override void ActivateSkill()
    {
        cast = true;
    }

    void Update()
    {
        if (cast)
        {
            Debug.Log("StealHP");
            cast = false;
        }
    }
}
