using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TreeEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movech : MonoBehaviour
{
    public Animator an;
    public GameObject pl;
    public GameObject wl;
    bool hleaf = false;
    public int health;
    float max_speed;
    public int p = 20;
    bool p_zone = false;

    Rigidbody2D rigid;
    Animator ani;
    void Start()
    {
        max_speed = 40;
        an = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        ani = pl.GetComponent<Animator>();
        health = 3;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "leaf")
        {
            Debug.Log("leaf");
            StartCoroutine(leaf());
        }
        if(other.tag == "p_zone")
        {
            p_zone = true;
        }
        if (other.tag == "snake")
        {
            StartCoroutine(End());
        }
    }
    IEnumerator End()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("EndScence");

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "p_zone")
        {
            p_zone = false;
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
        if (gameObject.transform.position.y <= 7.5)
        {
            rigid.gravityScale = 7;
        }
        else
        {
            rigid.gravityScale = 60;
        }
        //rigid.gravityScale = (gameObject.transform.position.y*2)/3 + 3 * gameObject.transform.position.y + 16;
        //Debug.Log(rigid.velocity);
        if(!p_zone)
        {
            if (Input.GetKeyDown(KeyCode.R) && !hleaf)
            {
                Move();
            }
            if (Input.GetKey(KeyCode.Space) && !hleaf)
            {
                rigidJump();
            }
            if (Input.GetKeyDown(KeyCode.S) && !hleaf)
            {
                //an.SetTrigger("slide");
                Slide();
            } else if (Input.GetKeyUp(KeyCode.S))
            {
                an.SetTrigger("idle");
                ani.SetTrigger("idle");
            }
        }
        if(Input.GetKeyDown(KeyCode.P) && !hleaf && p_zone)
        {
            if(p <= 0)
            {
                Punch();
                wl.transform.Translate(300*Random.Range(100,250),0,0);
                p = 20;
            } else
            {
                p -= 1;
            }
        }


    }

    void Move()
    {
        
        if(rigid.velocity.x >= max_speed)
        {
            rigid.velocity = new Vector2(max_speed, rigid.velocity.y);
        } else
        {
            rigid.AddForce(Vector2.right * 700);
        }
        ani.SetTrigger("walk");
    }
    void rigidJump()
    {
        ani.SetTrigger("jump");
        float r;
        if (rigid.velocity.x > 0)
        {
            r = rigid.velocity.x - 0.1f;
        } else
        {
            r = 0;
        }
        rigid.velocity = new Vector2(r, 0);
        rigid.AddForce(Vector2.up * 300);
    }
    void Slide()
    {
        an.SetTrigger("slide");
        ani.SetTrigger("slide");
    }
    void Punch()
    {
        ani.SetTrigger("punch");
    }
}
