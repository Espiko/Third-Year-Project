using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minusyRay : MonoBehaviour {
    public float minusyRayhit;
    public List<float> minusyRaylengthList = new List<float>();

    void FixedUpdate()
    {
        float angle = 90f - 20.0842423915226f; //set angle of ray (~20 degree off the x axis)
        var direction = Quaternion.AngleAxis(angle, transform.forward) * -transform.up; //set the direction of the ray

        Ray ray = new Ray(transform.position, direction); //instantiate new ray that goes from the centre of the player out in the set direction
        RaycastHit hit;

        float rayDistance = 2.25f; //set the max raylength

        Debug.DrawLine(transform.position, transform.position + direction * rayDistance, Color.red); //draw a debug line to show ray

        if (Physics.Raycast(ray, out hit, rayDistance)) //if the ray hits anything
        {
            minusyRayhit = hit.distance; //set ray length to distance from player to the object that was hit
        }
        else //if the ray doesn't hit anything
        {
            minusyRayhit = rayDistance; //set the length to the max length
        }
        minusyRaylengthList.Add(minusyRayhit); //record ray lengths
    }
}
