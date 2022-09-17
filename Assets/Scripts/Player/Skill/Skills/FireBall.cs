using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Skill
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
            StartCoroutine(MoveBall());
            cast = false;
        }
    }

    IEnumerator MoveBall()
    {
        yield return new WaitForSeconds(0.3f);
        
        Ray ray = Camera.main.ScreenPointToRay(rayStartPos);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        GameObject temp = Instantiate(skillPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Destroy(temp, 10);

        while (temp.transform.position != hit.point || !temp)
        {
            temp.transform.position = Vector3.MoveTowards(temp.transform.position, hit.point, 1f);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(temp);
    }

}
