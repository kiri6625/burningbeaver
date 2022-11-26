using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TreeEditor;
using UnityEditorInternal;
using UnityEngine;

public class movech : MonoBehaviour
{
    public Animator an;
    public GameObject pl;
    bool hleaf = false;
    public int health;

    Rigidbody2D rigid;
    animch ani;
    void Start()
    {
        an = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        ani = pl.GetComponent<animch>();
        health = 3;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "leaf")
        {
            Debug.Log("leaf");
            StartCoroutine(leaf());
        }
        if(other.tag == "snake")
        {
            Debug.Log("snake");
            if (ani.punch)
            {
                Destroy(other.gameObject);
            }
        }
    }
    IEnumerator leaf()
    {
        hleaf = true;
        health -= 1;
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.left * 1000);
        rigid.AddForce(Vector2.up * 1000);
        yield return new WaitForSeconds(0.5f);
        hleaf = false;
    }

    void Update()
    {
        if (health <= 0)
        {
           
        }
        if (!ani.jump && !ani.slide && !ani.punch)
        {
            ani.ani.speed = 0;
        }
        if (Input.GetKey(KeyCode.R)&&!hleaf)
        {
            Move();
        }
        if(Input.GetKeyDown(KeyCode.Space) && !hleaf)
        {
            rigidJump();
        }
        if (Input.GetKey(KeyCode.S) && !hleaf)
        {
            //an.SetTrigger("slide");
            Slide();
        }
        if(Input.GetKeyDown(KeyCode.P) && !hleaf)
        {
            Punch();
        }

    }

    void Move()
    {
        gameObject.transform.Translate(20*Time.deltaTime, 0, 0);
        if (!ani.jump && !ani.slide && !ani.punch)
        {
            ani.Walk();
        }
    }
    void rigidJump()
    {
        if (!ani.jump && !ani.slide && !ani.punch)
        {
            StartCoroutine(ani.Jump());
        }
        rigid.AddForce(Vector2.up * 1500);
    }
    void Slide()
    {
        if (!ani.jump && !ani.slide && !ani.punch)
        {
            StartCoroutine(ani.Slide());
        }
    }
    void Punch()
    {
        if(!ani.jump && !ani.slide && !ani.punch)
        {
            StartCoroutine(ani.Punch());
        }
    }
}
