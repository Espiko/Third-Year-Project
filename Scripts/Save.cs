using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    private float minusyRaylistlength, yRaylistlength, actionslistlength, xposlistlength, yposlistlength, stepslistlength;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnApplicationQuit()
    {
        SaveminusyRay();
        SaveyRay();
        SaveActions();
        SaveyPos();
        SavexPos();
        SaveSteps();
    }

    void SaveminusyRay()
    {
        string minusyraypath = Application.dataPath + "minusyray.txt"; //set path for new text file
        if (File.Exists(minusyraypath)) //if the file already exists, display error and exit
        {
            Debug.Log(minusyraypath + " already exists.");
            return;
        }
        StreamWriter sr = System.IO.File.CreateText(minusyraypath);
        minusyRaylistlength = player.GetComponent<minusyRay>().minusyRaylengthList.Count; //get the length of the list to be saved
        for (int i = 0; i < minusyRaylistlength; i++) //for every element in the list...
        {
            sr.WriteLine(player.GetComponent<minusyRay>().minusyRaylengthList[i]); //...write it to the text file
        }
        sr.Close();
    }

    void SaveyRay()
    {
        string yraypath = Application.dataPath + "yray.txt";
        if (File.Exists(yraypath))
        {
            Debug.Log(yraypath + " already exists.");
            return;
        }
        StreamWriter sr = System.IO.File.CreateText(yraypath);
        yRaylistlength = player.GetComponent<yRay>().yRaylengthList.Count;
        for (int i = 0; i < yRaylistlength; i++)
        {
            sr.WriteLine(player.GetComponent<yRay>().yRaylengthList[i]);
        }
        sr.Close();
    }

    void SaveActions() //this function must be edited depending on whether the agent actions or BasicControl actions are being saved
    {
        string actionspath = Application.dataPath + "actions.txt";
        if (File.Exists(actionspath))
        {
            Debug.Log(actionspath + " already exists.");
            return;
        }
        StreamWriter sr = System.IO.File.CreateText(actionspath);
        actionslistlength = player.GetComponent<CollisionAvoidanceAgent>().agentactionsList.Count;
        //actionslistlength = player.GetComponent<BasicControl>().actionsList.Count;
        for (int i = 0; i < actionslistlength; i++)
        {
            sr.WriteLine(player.GetComponent<CollisionAvoidanceAgent>().agentactionsList[i]);
            //sr.WriteLine(player.GetComponent<BasicControl>().actionsList[i]);
        }
        sr.Close();
    }

    void SavexPos()
    {
        string xpospath = Application.dataPath + "xpos.txt";
        if (File.Exists(xpospath))
        {
            Debug.Log(xpospath + " already exists.");
            return;
        }
        StreamWriter sr = System.IO.File.CreateText(xpospath);
        xposlistlength = player.GetComponent<globalpositionList>().positionListx.Count;
        for (int i = 0; i < xposlistlength; i++)
        {
            sr.WriteLine(player.GetComponent<globalpositionList>().positionListx[i]);
        }
        sr.Close();
    }

    void SaveyPos()
    {
        string ypospath = Application.dataPath + "ypos.txt";
        if (File.Exists(ypospath))
        {
            Debug.Log(ypospath + " already exists.");
            return;
        }
        StreamWriter sr = System.IO.File.CreateText(ypospath);
        yposlistlength = player.GetComponent<globalpositionList>().positionListy.Count;
        for (int i = 0; i < yposlistlength; i++)
        {
            sr.WriteLine(player.GetComponent<globalpositionList>().positionListy[i]);
        }
        sr.Close();
    }

    void SaveSteps()
    {
        string stepspath = Application.dataPath + "stepsbeforecollision.txt";
        if (File.Exists(stepspath))
        {
            Debug.Log(stepspath + " already exists.");
            return;
        }
        StreamWriter sr = System.IO.File.CreateText(stepspath);
        stepslistlength = player.GetComponent<CollisionAvoidanceAgent>().agentsurvivaltimeList.Count;
        for (int i = 0; i < stepslistlength; i++)
        {
            sr.WriteLine(player.GetComponent<CollisionAvoidanceAgent>().agentsurvivaltimeList[i]);
        }
        sr.Close();

    }
}
