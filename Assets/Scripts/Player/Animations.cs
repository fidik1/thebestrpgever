using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private Player player;

    private void Start()
    {
        player = anim.GetComponent<Player>();
    }

    private void Update()
    {
        if (player.vertical > 0 && player.horizontal == 0)
            anim.SetBool("isRunForward", true);
        else
            anim.SetBool("isRunForward", false);
        
        if (player.vertical < 0 && player.horizontal == 0)
            anim.SetBool("isRunBack", true);
        else
            anim.SetBool("isRunBack", false);
        
        if (player.horizontal > 0)
            anim.SetBool("isRunRight", true);
        else
            anim.SetBool("isRunRight", false);
        
        if (player.horizontal < 0)
            anim.SetBool("isRunLeft", true);
        else
            anim.SetBool("isRunLeft", false);
    }
    
    public void CastAnim(int skillID)
    {
        if (skillID >= 0 && skillID <= 4)
        {
            anim.SetBool("isCast", false);
            anim.SetBool("isCast", true);
            StartCoroutine(CheckAnimation("isCast", 1.05f));
        }
    }

    public void Jump()
    {
        anim.SetBool("isJump", true);
        StartCoroutine(CheckAnimation("isJump", 2.367f));
    }

    IEnumerator CheckAnimation(string name, float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool(name, false);
        StopCoroutine(CheckAnimation("isJump", 0f));
    }
}
