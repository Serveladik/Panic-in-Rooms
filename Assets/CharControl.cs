using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody rb;
    public float sensitivityToSpeed;

    void Start()
    {
        joystick=FindObjectOfType<Joystick>();
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
    }
}
