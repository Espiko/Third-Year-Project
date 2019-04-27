using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class BasicControl : MonoBehaviour {
    private float yRay, minusyRay, turnRate;
    private GameObject player;
    public List<float> actionsList = new List<float>(); //create list to keep track of actions

    void Start()
    {
        turnRate = 125f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
            //get ray lengths
            yRay = player.GetComponent<yRay>().yRayhit; 
            minusyRay = player.GetComponent<minusyRay>().minusyRayhit;

            if (minusyRay < yRay) //if top ray is shorter than bottom ray, turn towards bottom ray (right)
            {
                transform.Rotate(0f, 0f, turnRate * Time.fixedDeltaTime);
                actionsList.Add(-1f); //record right turn
            }
            else if (yRay < minusyRay) //if bottom ray is shorter than top ray, turn towards top ray (left)
            {
                transform.Rotate(0f, 0f, -turnRate * Time.fixedDeltaTime);
                actionsList.Add(1f); //record left turn
            }
            else if (yRay == minusyRay && yRay < 2.25f) //if both rays are equal but a crash is about to happen, turn upwards (left)
            {
                transform.Rotate(0f, 0f, -turnRate * Time.fixedDeltaTime);
                actionsList.Add(-1f); //record left turn
            }
            else
            {
                actionsList.Add(0f); //record no action made
            }
        //}
    }
}
