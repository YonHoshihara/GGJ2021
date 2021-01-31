using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField]private Rigidbody2D rb;
    void Start()
    {

    }
    void Update()
    {
        anim.SetFloat("velocity", Mathf.Abs(rb.velocity.x));
    }
   
    public void SetStartShootTriger()
    {
        anim.SetTrigger("startShoot");
    }
    public void SetEndtShootTriger()
    {
        anim.SetTrigger("endShoot");
    }

    public void SetDashtrigger()
    {
        anim.SetTrigger("dash");
    }

    public void SetEndDashtrigger()
    {
        anim.SetTrigger("endDash");
    }
}
