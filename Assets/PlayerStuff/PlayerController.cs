using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float damage;
    public Transform gC;
    bool groundCheck;

    Animator anim;
    SpriteRenderer sR;

    Collider2D[] stickHits;

    AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal"), transform.position.y + Input.GetAxisRaw("Vertical"), 0), speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, Vector3.zero) > 5)
        {
            transform.position = transform.position.normalized * 5;
        }
        
        
        HandleAnimation();
        if (FindObjectsOfType<plantscript>().Length == 0)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))//swing the stick
        {
            aS.Play();
            foreach( Collider2D coll in Physics2D.OverlapCircleAll(transform.position + new Vector3(1.5f*transform.localScale.x, 0.5f, 0), 0.5f))
            {
                if (coll != null && coll.gameObject.CompareTag("plant"))
                {
                    coll.gameObject.GetComponent<plantscript>().plantfound();
                }
                if (coll != null && coll.gameObject.CompareTag("guy"))
                {
                    coll.gameObject.GetComponent<GuyScript>().WrongHit();
                    Debug.Log("Hit guy");
                }
            }
            
        }
    }


    void HandleAnimation()
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetBool("Moving", true);
            if(Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }
}
