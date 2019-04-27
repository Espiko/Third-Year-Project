using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour {
    private GameObject player;
    private Vector3 playerpos, objectpos;
    private float distance, steps;
    private bool restart;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        steps = 0;
    }

    void FixedUpdate()
    {
        steps += 1;
        restart = player.GetComponent<CollisionAvoidanceAgent>().destroyobstacle; //restart boolean is dictated by the whether the agent is resetting or not

        if (restart == true) //if the agent has reset, destroy the object that this script is attached to
        {
            GameObject.Destroy(this.gameObject);
        }

        playerpos = player.transform.position;
        objectpos = this.transform.position;
        distance = Vector3.Distance(objectpos, playerpos);

        if (distance > 6f || steps > 300) //if the obstacle is too far from the agent or if it has existed for more than a certain number of steps then destroy it
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
