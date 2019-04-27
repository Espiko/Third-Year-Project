using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardVelocity : MonoBehaviour {
    private float speed;
    private Rigidbody rb;

    void Start()

    {
        rb = GetComponent<Rigidbody>();
        speed = 2f;
    }

    void FixedUpdate()
    {
        rb.velocity = this.transform.right * speed; //set a constant speed in the player's local positive X direction 
    }
}
