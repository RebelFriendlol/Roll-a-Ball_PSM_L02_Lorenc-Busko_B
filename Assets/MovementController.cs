using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float thrust = 0.5f;
    public float jumpthrust = 10f;
    public Rigidbody rb;
    public int score = 0;
    private bool w = false;
    private bool a = false;
    private bool s = false;
    private bool d = false;
    private bool space = false;
    private bool isGrounded = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        w = Input.GetKey(KeyCode.W);
        a = Input.GetKey(KeyCode.A);
        s = Input.GetKey(KeyCode.S);
        d = Input.GetKey(KeyCode.D);
        space = Input.GetKey(KeyCode.Space); 
    }

    void FixedUpdate()
    {
        if (w)
        {
            rb.AddForce(0, 0, thrust);
        }

        if (a)
        {
            rb.AddForce(-thrust, 0, 0);
        }

        if (s)
        {
            rb.AddForce(0, 0, -thrust);
        }

        if (d)
        {
            rb.AddForce(thrust, 0, 0);
        }

       
        if (space && isGrounded)
        {
            rb.AddForce(0, jumpthrust, 0, ForceMode.Impulse); 
        }
    }

    
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            isGrounded = true; 
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false; 
        }
    }
}
