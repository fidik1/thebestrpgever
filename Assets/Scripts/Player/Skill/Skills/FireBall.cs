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
            Ray ray = Camera.main.ScreenPointToRay(rayStartPos);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            GameObject temp = Instantiate(skillPrefab, player.transform.position, player.transform.rotation);
            //temp.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10f);
            StartCoroutine(MoveBall(temp, hit));
            Destroy(temp, 10);
            cast = false;
        }
    }

    IEnumerator MoveBall(GameObject temp, RaycastHit hit)
    {
        while (temp.transform.position != hit.point || !temp)
        {
            temp.transform.position = Vector3.MoveTowards(temp.transform.position, hit.point, 1f);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(temp);
    }

}
