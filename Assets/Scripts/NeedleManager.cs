using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleManager : MonoBehaviour
{
    private GameObject player;
    private GameObject needle;
    private Transform[] objectives = new Transform[4];
    public bool spinningCompass = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        needle = GameObject.FindGameObjectsWithTag("Needle")[0];
        needle.transform.position = transform.position + new Vector3(0,0,-.1f);
        objectives[0] = GameObject.FindGameObjectsWithTag("Obj1")[0].transform;
        objectives[1] = GameObject.FindGameObjectsWithTag("Obj2")[0].transform;
        objectives[2] = GameObject.FindGameObjectsWithTag("Obj3")[0].transform;
        objectives[3] = GameObject.FindGameObjectsWithTag("Obj4")[0].transform;
    }

    // https://forum.unity.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
    string GetClosestObjective (Transform[] objectives)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = player.transform.position;
        foreach(Transform potentialTarget in objectives)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget > 100.0f) continue; // this allows us to teleport objectives far away and not have them be recognized by compass
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        if (bestTarget == null) {
            return null;
        } else {
            return bestTarget.gameObject.name;
        }
    }


    // Update is called once per frame
    void Update()
    {
        float x = needle.transform.localEulerAngles.x;
        float y = needle.transform.localEulerAngles.y;
        string objName = GetClosestObjective(objectives);
        if (spinningCompass) objName = "none";
        switch (objName)
        {
            case "Objective1":
                needle.transform.localEulerAngles = new Vector3(x,y,90);
                needle.transform.position = transform.position + new Vector3(0,.6f,-.1f);
                break;
            case "Objective2":
                needle.transform.localEulerAngles = new Vector3(x,y,180);
                needle.transform.position = transform.position + new Vector3(-.6f,0,-.1f);
                break;
            case "Objective3":
                needle.transform.localEulerAngles = new Vector3(x,y,270);
                needle.transform.position = transform.position + new Vector3(0,-.6f,-.1f);
                break;
            case "Objective4":
                needle.transform.localEulerAngles = new Vector3(x,y,0);
                needle.transform.position = transform.position + new Vector3(.6f,0,-.1f);
                break;
            default:
                needle.transform.RotateAround(transform.position, Vector3.forward, 450 * Time.deltaTime);
                break;
        }
        
    }
}
