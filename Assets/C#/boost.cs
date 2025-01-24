using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boost : MonoBehaviour
{
    public Rigidbody rb;
   
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider collision)
    {
        rb.AddForce(0, 15, 0, ForceMode.Impulse);

    }
}
