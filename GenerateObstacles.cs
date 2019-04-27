using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour {
    private float ForwardNumber, BehindNumber, minDistancey, maxDistancey, ForwardCount, BehindCount, xdist, xdistbehind, ydist;
    private GameObject player;
    private Vector3 playerpos, playerdir, playerorthog;
    private Quaternion rotation;

    void Start () {
        ForwardNumber = 2f; //number of allowable obstacles in front of the player
        BehindNumber = 1f; //number of obstacles behind the player

        xdist = 5f; //x distance from the player for the obstacles infront 
        //range of y values for the obstacles in front of the player ranges from minDistancey to maxDistancey
        minDistancey = -5f; 
        maxDistancey = 5f;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        //get the number of obstacles infront of the player than currently exist
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        ForwardCount = obstacles.Length; 

        if (ForwardCount < ForwardNumber) //if there is less than the maximum number of obstacles infront of the player then
        {
            ydist = Random.Range(minDistancey, maxDistancey); //generate a random y coordinate in the set range

            playerpos = player.transform.position; //get the player position
            playerdir = player.transform.right; //get the player direction (x)
            playerorthog = player.transform.up; //get the orthogonal player direction (y)
            rotation = Quaternion.Euler(0, 0, 0); //set the rotation as zero

            Vector3 spwnPos = (playerdir * xdist) + (playerorthog * ydist) + player.transform.position; //set the object spawn position as xdist infront of the player and ydist in the y direction

            GameObject obstacle = Instantiate(Resources.Load("Obstacle"), spwnPos, rotation) as GameObject; //instantiate obstacle prefab
        }

        //get number of obstacles behind the player
        GameObject[] behindobstacle = GameObject.FindGameObjectsWithTag("behindobstacle");
        BehindCount = behindobstacle.Length;

        if (BehindCount < BehindNumber) //if the number of obstacles is less than the maximum then
        {
            playerpos = player.transform.position; //get player position
            playerdir = player.transform.right; //get player direction (x)
            rotation = player.transform.rotation; //get player rotation

            xdistbehind = -2.25f; //set x distance behind player

            Vector3 spwnPos = (playerdir * xdistbehind) + player.transform.position; //set spawn position relative to player

            GameObject obstacle = Instantiate(Resources.Load("BehindObstacle"), spwnPos, rotation) as GameObject; //instantiate obstacle prefab
        }

    }
}
