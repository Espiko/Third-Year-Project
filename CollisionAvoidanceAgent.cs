using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class CollisionAvoidanceAgent : Agent
{
    private float CollisionReward, TimeReward;
    private float raycastmax, yRaylength, minusyRaylength, yRaynorm, minusyRaynorm;
    private float turnRate, steps, runnumber;
    public bool destroyobstacle;
    public List<float> agentactionsList = new List<float>(); //create list to keep track of actions
    public List<float> agentsurvivaltimeList = new List<float>(); //create list to keep track of steps before collision
    private GameObject player;
    private const int NoAction = 0;  //do nothing
    private const int Up = 1;
    private const int Down = 2;
    private Vector3 Circle;
    public void Awake()
    {
        //
    }

    public override void InitializeAgent()
    {
        steps = 0f;
        runnumber = 0f;
        turnRate = 125f;

        CollisionReward = -1f;
        TimeReward = 0.01f;

        player = GameObject.FindGameObjectWithTag("Player");

        raycastmax = 2.25f;
    }

    public override void AgentReset()
    {
        destroyobstacle = false;

        //reset velocities, position and rotation
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        player.transform.rotation = Quaternion.Euler(0, 180, 180);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        player.transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        player.transform.rotation = Quaternion.Euler(0, 180, 180);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        steps = 0f;
    }

    public override void CollectObservations()
    {

        yRaylength = player.GetComponent<yRay>().yRayhit; 
        minusyRaylength = player.GetComponent<minusyRay>().minusyRayhit;

        //normalize current ray lengths
        yRaynorm = yRaylength / raycastmax; 
        minusyRaynorm = minusyRaylength / raycastmax;

        //add observations of the normalised raycast lengths
        AddVectorObs(yRaynorm);
        AddVectorObs(minusyRaynorm);
    }

    public override void AgentAction(float[] actions, string textAction)
    {
        steps += 1;
        destroyobstacle = false;
        int action = Mathf.FloorToInt(actions[0]);

        //list of actions that the agent can take
        switch (action)
        {
            case NoAction:
                // do nothing
                agentactionsList.Add(0f); //record that the agent decided to do nothing
                break;
            case Up:
                player.transform.Rotate(0f, 0f, -turnRate * Time.fixedDeltaTime);
                agentactionsList.Add(1f); //record that the agent decided to turn left
                break;
            case Down:
                player.transform.Rotate(0f, 0f, turnRate * Time.fixedDeltaTime);
                agentactionsList.Add(-1f); //record that the agent decided to turn right
                break;
        }

        if (player.GetComponent<CollisionDetection>().Collision == true) //if player collides, give collision reward and end episode
        {
            AddReward(CollisionReward);
            player.GetComponent<CollisionDetection>().Collision = false;
            destroyobstacle = true; //destroy all obstacles in order to reset
            agentsurvivaltimeList.Add(steps);
            runnumber += 1;
            Debug.Log("Run Number: " + runnumber);
            Done();
        }

        AddReward(TimeReward); //add reward every time step

        if (steps == 5000f) //if the agent 'survives' for the maximum number of steps, restart
        {
            destroyobstacle = true;
            agentsurvivaltimeList.Add(steps);
            runnumber += 1;
            Debug.Log("Run Number: " + runnumber);
            Done();
        }

    }
}