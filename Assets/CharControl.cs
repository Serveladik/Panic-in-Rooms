using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody rb;
    public float sensitivityToSpeed;
    private Quaternion playerRotation;

    void Start()
    {
        if(joystick==null)
        {
            joystick=FindObjectOfType<Joystick>();
        }
        rb = GetComponent<Rigidbody>();
        playerRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }
    void PlayerControl()
    {
        rb.velocity = new Vector3 (joystick.Horizontal * sensitivityToSpeed/3,rb.velocity.y,joystick.Vertical * sensitivityToSpeed/3);
        //Look at movement vector
        if(Input.touchCount>=1)
        {
            playerRotation = Quaternion.LookRotation(rb.velocity);
            Debug.Log("ROT");
        }
        else
        {
            transform.rotation = playerRotation;
        }
        
    }
    void PlayerRotation()
    {

    }
}
