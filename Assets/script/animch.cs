using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animch : MonoBehaviour
{
    public Animator ani;
    public bool jump = false;
    public bool slide = false;
    public bool punch = false;
    private void Start()
    {
        ani = GetComponent<Animator>();
        ani.speed = 0;
    }

    public void Walk()
    {
        ani.speed = 1;
    }
    public IEnumerator Slide()
    {

        slide = true;
        ani.SetTrigger("slide");
        ani.speed = 1;
        yield return new WaitForSeconds(0.7f);
        ani.speed = 0;
        slide = false;
    }
    public IEnumerator Jump()
    {

        jump= true;
        ani.SetTrigger("jump");
        ani.speed = 1;
        yield return new WaitForSeconds(0.4f);
        ani.speed = 0;
        jump = false;
    }
    public IEnumerator Punch()
    {
        punch= true;
        ani.SetTrigger("punch");
        ani.speed = 1;
        yield return new WaitForSeconds(0.4f);
        Debug.Log("³¡");
        ani.speed = 0;
        punch = false;
    }
}
