using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBall : Skill
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
            var temp = Instantiate(skillPrefab, player.transform.position, player.transform.rotation);
            temp.GetComponent<Rigidbody>().AddForce(player.transform.up * 10f, ForceMode.Impulse);
            Destroy(temp, 10);
            cast = false;
        }
    }
}
