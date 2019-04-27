using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {
    public bool Collision;

    void Start()
    {
        Collision = false;
    }
    void OnCollisionEnter(Collision col) //if player collides with anything, set collision = true
    {
        Collision = true;
    }
}
