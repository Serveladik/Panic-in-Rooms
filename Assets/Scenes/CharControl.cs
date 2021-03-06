﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    private Rigidbody rb;
    public float sensitivityToSpeed;
    public Animator playerAnim;
    public Joystick joystick;

    void Start()
    {
        if(joystick==null)
        {
            joystick=FindObjectOfType<Joystick>();
        }
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerControl();
    }
    void PlayerControl()
    {
        rb.velocity = new Vector3 (joystick.Horizontal * sensitivityToSpeed/3,rb.velocity.y,joystick.Vertical * sensitivityToSpeed/3);
        if(rb.velocity.magnitude>0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(rb.velocity),0.08f);
        } 
        AnimatorStates();
    }

    void AnimatorStates()
    {
        if(rb.velocity.magnitude<=0f)
        {
            playerAnim.SetBool("Idle",true);
            playerAnim.SetBool("Walk",false);
            playerAnim.SetBool("Run",false);
        }
        if(rb.velocity.magnitude>=0.5f && rb.velocity.magnitude<=2.5f)
        {
            playerAnim.SetBool("Idle",false);
            playerAnim.SetBool("Walk",true);
            playerAnim.SetBool("Run",false);
        }
        if(rb.velocity.magnitude>2.5f)
        {
            playerAnim.SetBool("Idle",false);
            playerAnim.SetBool("Walk",false);
            playerAnim.SetBool("Run",true);
        }
    }
}
