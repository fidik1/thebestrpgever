using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMovementSpeed : Skill
{
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
            Debug.Log("IncreaseMS");
            cast = false;
        }
    }
}
