using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalpositionList : MonoBehaviour {
    private float globalpositionx, globalpositiony;
    private GameObject player;
    public List<float> positionListx = new List<float>(); //create list to keep track of x position
    public List<float> positionListy = new List<float>(); //create list to keep track of y position

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	

	void FixedUpdate () {
        globalpositionx = player.transform.position.x;
        globalpositiony = player.transform.position.y;

        positionListx.Add(globalpositionx);
        positionListy.Add(globalpositiony);

    }
}
