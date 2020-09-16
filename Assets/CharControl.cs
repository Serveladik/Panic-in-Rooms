﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody rb;
    public float sensitivityToSpeed;
    [SerializeField]private GameObject destroyedObstacles;
    public Animator playerAnim;
    [Header("Animator List")]
    public RuntimeAnimatorController[] animatorOverride;

    void Start()
    {
        if(joystick==null)
        {
            joystick=FindObjectOfType<Joystick>();
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }
    void PlayerControl()
    {
        
        rb.velocity = new Vector3 (joystick.Horizontal * sensitivityToSpeed/3,rb.velocity.y,joystick.Vertical * sensitivityToSpeed/3);
        Debug.Log(rb.velocity.magnitude);
        //Look at movement vector
        if(Input.touchCount>=1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(rb.velocity),0.15f);
        } 
        AnimatorStates();
    }

    void AnimatorStates()
    {
        
        if(rb.velocity.magnitude<=0f)
        {
            playerAnim.runtimeAnimatorController = animatorOverride[0] as RuntimeAnimatorController;
        }
        
        if(rb.velocity.magnitude>=0.5f && rb.velocity.magnitude<=2.5f)
        {
            playerAnim.runtimeAnimatorController = animatorOverride[1] as RuntimeAnimatorController;
        }
        
        if(rb.velocity.magnitude>2.5f)
        {
            playerAnim.runtimeAnimatorController = animatorOverride[2] as RuntimeAnimatorController;
        }
        
    }

    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "WeakWall")
        {
            destroyedObstacles = Instantiate(destroyedObstacles,player.transform.position,Quaternion.identity) as GameObject;
            player.gameObject.SetActive(false);
        }
    }
}
